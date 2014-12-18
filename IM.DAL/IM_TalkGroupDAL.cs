using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using XSAT.Lib2014.System.Data;
using IM.Model;

namespace IM.DAL
{
    /// <summary>
    /// 数据访问类:IM_TalkGroupDAL
    /// </summary>
    public partial class IM_TalkGroupDAL
    {
        public IM_TalkGroupDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TalkGroupInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("insert into IM_TalkGroup(");
            strSql.Append("ID,SendUserID,GroupID,Note,Type,State,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@SendUserID,@GroupID,@Note,@Type,@State,@CreateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Note", SqlDbType.NVarChar),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[n++].Value = model.ID;
            parameters[n++].Value = model.SendUserID;
            parameters[n++].Value = model.GroupID;
            parameters[n++].Value = model.Note;
            parameters[n++].Value = model.Type;
            parameters[n++].Value = model.State;
            parameters[n++].Value = model.CreateDate;

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
        public bool Update(IM_TalkGroupInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_TalkGroup set ");
            strSql.Append("SendUserID=@SendUserID,");
            strSql.Append("GroupID=@GroupID,");
            strSql.Append("Note=@Note,");
            strSql.Append("Type=@Type,");
            strSql.Append("State=@State,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Note", SqlDbType.NVarChar),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = model.SendUserID;
            parameters[n++].Value = model.GroupID;
            parameters[n++].Value = model.Note;
            parameters[n++].Value = model.Type;
            parameters[n++].Value = model.State;
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
            strSql.Append("update IM_TalkGroup set IsDelete=1 ");
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
        public IM_TalkGroupInfo GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SendUserID,GroupID,Note,Type,State,CreateDate from IM_TalkGroup ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            IM_TalkGroupInfo model = new IM_TalkGroupInfo();
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
        public IM_TalkGroupInfo DataRowToModel(DataRow row)
        {
            IM_TalkGroupInfo model = new IM_TalkGroupInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["SendUserID"] != null && row["SendUserID"].ToString() != "")
                {
                    model.SendUserID = new Guid(row["SendUserID"].ToString());
                }
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = new Guid(row["GroupID"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
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
        public List<IM_TalkGroupInfo> GetList(QueryBuilder queryBuilder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (queryBuilder.Top > 0)
            {
                strSql.Append(" top " + queryBuilder.Top);
            }
            strSql.Append(" ID,SendUserID,GroupID,Note,Type,State,CreateDate ");
            strSql.Append(" FROM IM_TalkGroup ");
            strSql.Append(queryBuilder.Where);
            strSql.Append(queryBuilder.Order);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<IM_TalkGroupInfo> list = new List<IM_TalkGroupInfo>();
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
            sbSql.Append(@"SELECT * FROM IM_TalkGroup" + queryBuilder.Where);
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
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_TalkGroup");
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
        /// 获取群聊天信息
        /// <param name="userID">userID</param>
        /// </summary>
        public List<IM_TalkGroupInfo> GetList(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_TalkGroup].*,GroupName,UserName from [dbo].[IM_TalkGroup]
inner join [dbo].[IM_TalkGroupHint]
on [IM_TalkGroup].ID=[IM_TalkGroupHint].[TalkGroupID]
inner join [dbo].[IM_Group]
on [IM_TalkGroup].GroupID=[IM_Group].ID
inner join [dbo].[IM_User]
on [SendUserID]=[IM_User].ID
where [IM_TalkGroupHint].UserID=@UserID and SendUserID<>@UserID and [IM_TalkGroupHint].State=0 order by [CreateDate] asc ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_TalkGroupInfo> list = new List<IM_TalkGroupInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_TalkGroupInfo model = new IM_TalkGroupInfo();
                if (row != null)
                {
                    if (row["ID"] != null && row["ID"].ToString() != "")
                    {
                        model.ID = new Guid(row["ID"].ToString());
                    }
                    if (row["SendUserID"] != null && row["SendUserID"].ToString() != "")
                    {
                        model.SendUserID = new Guid(row["SendUserID"].ToString());
                    }
                    if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                    {
                        model.GroupID = new Guid(row["GroupID"].ToString());
                    }
                    if (row["Note"] != null)
                    {
                        model.Note = row["Note"].ToString();
                    }
                    if (row["Type"] != null && row["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(row["Type"].ToString());
                    }
                    if (row["State"] != null && row["State"].ToString() != "")
                    {
                        model.State = int.Parse(row["State"].ToString());
                    }
                    if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                    }
                    if (row["GroupName"] != null && row["GroupName"].ToString() != "")
                    {
                        model.GroupName = row["GroupName"].ToString();
                    }
                    if (row["UserName"] != null && row["UserName"].ToString() != "")
                    {
                        model.UserName = row["UserName"].ToString();
                    }
                }
                list.Add(model);
            }
            return list;
        }


        /// <summary>
        /// 获取未查看群聊信息
        /// <param name="groupID">groupID</param>
        /// <param name="userID">userID</param>
        /// </summary>
        public List<IM_TalkGroupInfo> GetList(Guid groupID, Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_TalkGroup].*,UserName from [dbo].[IM_TalkGroup]
inner join [dbo].[IM_User]
on [IM_TalkGroup].[SendUserID]=[IM_User].ID
where [CreateDate]>=
(select top 1 [IM_TalkGroup].[CreateDate] from [dbo].[IM_TalkGroup]
inner join
[dbo].[IM_TalkGroupHint]
on [IM_TalkGroup].ID=[TalkGroupID]
where [IM_TalkGroup].[GroupID]=@GroupID and [UserID]=@UserID and [IM_TalkGroupHint].State=1
order by [CreateDate] asc) and [GroupID]=@GroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = userID;
            parameters[1].Value = groupID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_TalkGroupInfo> list = new List<IM_TalkGroupInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_TalkGroupInfo model = new IM_TalkGroupInfo();
                if (row != null)
                {
                    if (row["ID"] != null && row["ID"].ToString() != "")
                    {
                        model.ID = new Guid(row["ID"].ToString());
                    }
                    if (row["SendUserID"] != null && row["SendUserID"].ToString() != "")
                    {
                        model.SendUserID = new Guid(row["SendUserID"].ToString());
                    }
                    if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                    {
                        model.GroupID = new Guid(row["GroupID"].ToString());
                    }
                    if (row["Note"] != null)
                    {
                        model.Note = row["Note"].ToString();
                    }
                    if (row["Type"] != null && row["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(row["Type"].ToString());
                    }
                    if (row["State"] != null && row["State"].ToString() != "")
                    {
                        model.State = int.Parse(row["State"].ToString());
                    }
                    if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                    }
                    if (row["UserName"] != null && row["UserName"].ToString() != "")
                    {
                        model.UserName = row["UserName"].ToString();
                    }
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 分页获取数据列表
        /// <param name="GroupID"></param>
        /// <param name="UserID"></param>
        /// <param name="queryBuilder"></param>
        /// <param name="iRecordCount"></param>
        /// </summary>
        public DataTable GetListByPage(string groupID, string userID, QueryBuilder queryBuilder, ref int iRecordCount)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"
select [dbo].[IM_TalkGroup].*,UserName from [dbo].[IM_TalkGroup]
inner join [dbo].[IM_TalkGroupHint]
on [IM_TalkGroup].ID=[TalkGroupID]
inner join [dbo].[IM_User]
on [IM_User].ID=SendUserID
where [IM_TalkGroup].GroupID='" + groupID + @"' and UserID='" + userID + @"' and IsDelete=0 ");
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
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_TalkGroup");
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
        #endregion  ExtensionMethod
    }
}

