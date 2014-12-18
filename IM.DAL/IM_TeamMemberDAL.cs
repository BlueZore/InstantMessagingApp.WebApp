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
    /// 数据访问类:IM_TeamMemberDAL
    /// </summary>
    public partial class IM_TeamMemberDAL
    {
        public IM_TeamMemberDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TeamMemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append(@"if exists(select 1 from IM_TeamMember where UserID=@UserID and TeamID=@TeamID)
                             begin
                                    select -1 as ifCanDo
                                    return
                             end ");
            strSql.Append("insert into IM_TeamMember(");
            strSql.Append("TeamID,UserID,OrderIndex)");
            strSql.Append(" values (");
            strSql.Append("@TeamID,@UserID,@OrderIndex)");
            SqlParameter[] parameters = {
					new SqlParameter("@TeamID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4)};
            parameters[n++].Value = model.TeamID;
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
        public bool Update(IM_TeamMemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_TeamMember set ");
            strSql.Append("TeamID=@TeamID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("OrderIndex=@OrderIndex");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TeamID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@OrderIndex", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = model.TeamID;
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
            strSql.Append("update IM_TeamMember set IsDelete=1 ");
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
        public IM_TeamMemberInfo GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,TeamID,UserID,OrderIndex from IM_TeamMember ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            IM_TeamMemberInfo model = new IM_TeamMemberInfo();
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
        public IM_TeamMemberInfo DataRowToModel(DataRow row)
        {
            IM_TeamMemberInfo model = new IM_TeamMemberInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["TeamID"] != null && row["TeamID"].ToString() != "")
                {
                    model.TeamID = new Guid(row["TeamID"].ToString());
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
        public List<IM_TeamMemberInfo> GetList(QueryBuilder queryBuilder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (queryBuilder.Top > 0)
            {
                strSql.Append(" top " + queryBuilder.Top);
            }
            strSql.Append(" ID,TeamID,UserID,OrderIndex ");
            strSql.Append(" FROM IM_TeamMember ");
            strSql.Append(queryBuilder.Where);
            strSql.Append(queryBuilder.Order);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<IM_TeamMemberInfo> list = new List<IM_TeamMemberInfo>();
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
            sbSql.Append("SELECT * FROM IM_TeamMember" + queryBuilder.Where);
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
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_TeamMember");
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
        /// 增加一条数据
        /// <param name="SendUser">发送用户</param>
        /// <param name="CurrUser">当前用户</param>
        /// </summary>
        public bool AddForSendUser(Guid sendUser, Guid currUser)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append(" declare @TeamID uniqueidentifier ");
            strSql.Append(" select top 1 @TeamID=ID from [dbo].[IM_Team] where UserID=@SendUser order by CreateDate asc ");
            strSql.Append(@" if exists(select 1 from IM_TeamMember where UserID=@CurrUser and TeamID=@TeamID)
                             begin
                                    select -1 as ifCanDo
                                    return
                             end ");
            strSql.Append(" insert into IM_TeamMember(");
            strSql.Append("TeamID,UserID)");
            strSql.Append(" values (");
            strSql.Append("@TeamID,@CurrUser)");
            SqlParameter[] parameters = {
                    new SqlParameter("@SendUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CurrUser", SqlDbType.UniqueIdentifier,16)};

            parameters[n++].Value = sendUser;
            parameters[n++].Value = currUser;

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
        /// 获取所有组中成员
        /// <param name="UserID"></param>
        /// </summary>
        public List<IM_UserInfo> GetAllTeamMemberList(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select [IM_User].*,TeamID,TeamName from [dbo].[IM_TeamMember]
                            inner join [dbo].[IM_Team]
                            on [IM_TeamMember].TeamID=[IM_Team].ID
                            inner join [dbo].[IM_User]
                            on [IM_TeamMember].UserID=[IM_User].ID
                            where [IM_Team].UserID=@UserID
                            order by [IM_User].UserName asc");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_UserInfo> list = new List<IM_UserInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_UserInfo model = new IM_UserInfo();
                if (row != null)
                {
                    if (row["ID"] != null && row["ID"].ToString() != "")
                    {
                        model.ID = new Guid(row["ID"].ToString());
                    }
                    if (row["Sys_UserID"] != null)
                    {
                        model.Sys_UserID = row["Sys_UserID"].ToString();
                    }
                    if (row["UserName"] != null)
                    {
                        model.UserName = row["UserName"].ToString();
                    }
                    if (row["Pic"] != null)
                    {
                        model.Pic = row["Pic"].ToString();
                    }
                    if (row["LoginDate"] != null && row["LoginDate"].ToString() != "")
                    {
                        model.LoginDate = DateTime.Parse(row["LoginDate"].ToString());
                    }
                    if (row["LastDate"] != null && row["LastDate"].ToString() != "")
                    {
                        model.LastDate = DateTime.Parse(row["LastDate"].ToString());
                    }
                    if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                    {
                        model.IsDelete = int.Parse(row["IsDelete"].ToString());
                    }
                    if (row["TeamID"] != null && row["TeamID"].ToString() != "")
                    {
                        model.TeamID = new Guid(row["TeamID"].ToString());
                    }
                    if (row["TeamName"] != null)
                    {
                        model.TeamName = row["TeamName"].ToString();
                    }

                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 删除成员
        /// <param name="userID">userID</param>
        /// <param name="teamID">teamID</param>
        /// </summary>
        public bool Delete(Guid userID, Guid teamID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IM_TeamMember where UserID=@UserID and TeamID=@TeamID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),	
                    new SqlParameter("@TeamID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userID;
            parameters[1].Value = teamID;

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
        /// 修改成员组
        /// <param name="teamID">实体</param>
        /// <param name="oldTeamID">实体</param>
        /// <param name="userID">实体</param>
        /// </summary>
        public bool Update(Guid teamID, Guid oldTeamID, Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_TeamMember set ");
            strSql.Append("TeamID=@TeamID");
            strSql.Append(" where UserID=@UserID and TeamID=@OldTeamID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TeamID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@OldTeamID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = teamID;
            parameters[n++].Value = oldTeamID;
            parameters[n++].Value = userID;

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

