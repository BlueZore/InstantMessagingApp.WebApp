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
    /// 数据访问类:IM_TalkDAL
    /// </summary>
    public partial class IM_TalkDAL
    {
        public IM_TalkDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TalkInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("insert into IM_Talk(");
            strSql.Append("SendUserID,ReceiveUserID,Note,Type,State)");
            strSql.Append(" values (");
            strSql.Append("@SendUserID,@ReceiveUserID,@Note,@Type,@State)");
            SqlParameter[] parameters = {
					new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Note", SqlDbType.NVarChar),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[n++].Value = model.SendUserID;
            parameters[n++].Value = model.ReceiveUserID;
            parameters[n++].Value = model.Note;
            parameters[n++].Value = model.Type;
            parameters[n++].Value = model.State;

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
        public bool Update(IM_TalkInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_Talk set ");
            strSql.Append("SendUserID=@SendUserID,");
            strSql.Append("ReceiveUserID=@ReceiveUserID,");
            strSql.Append("Note=@Note,");
            strSql.Append("Type=@Type,");
            strSql.Append("State=@State,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Note", SqlDbType.NVarChar),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = model.SendUserID;
            parameters[n++].Value = model.ReceiveUserID;
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
            strSql.Append("update IM_Talk set IsDelete=1 ");
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
        public IM_TalkInfo GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SendUserID,ReceiveUserID,Note,Type,State,CreateDate from IM_Talk ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            IM_TalkInfo model = new IM_TalkInfo();
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
        public IM_TalkInfo DataRowToModel(DataRow row)
        {
            IM_TalkInfo model = new IM_TalkInfo();
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
                if (row["ReceiveUserID"] != null && row["ReceiveUserID"].ToString() != "")
                {
                    model.ReceiveUserID = new Guid(row["ReceiveUserID"].ToString());
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
        public List<IM_TalkInfo> GetList(QueryBuilder queryBuilder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (queryBuilder.Top > 0)
            {
                strSql.Append(" top " + queryBuilder.Top);
            }
            strSql.Append(" ID,SendUserID,ReceiveUserID,Note,Type,State,CreateDate ");
            strSql.Append(" FROM IM_Talk ");
            strSql.Append(queryBuilder.Where);
            strSql.Append(queryBuilder.Order);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<IM_TalkInfo> list = new List<IM_TalkInfo>();
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
            sbSql.Append("SELECT * FROM IM_Talk" + queryBuilder.Where);
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
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_Talk");
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
        /// 修改状态
        /// <param name="ID">实体</param>
        /// <param name="State">实体</param>
        /// </summary>
        public bool UpdateForState(Guid ID, int state)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_Talk set ");
            strSql.Append("State=@State");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = state;
            parameters[n++].Value = ID;

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
        /// 获取聊天信息
        /// <param name="UserID">ReceiveUserID</param>
        /// </summary>
        public List<IM_TalkInfo> GetList(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_Talk].*,UserName as SendUserName from [dbo].[IM_Talk]
inner join [dbo].[IM_User]
on [IM_Talk].[SendUserID]=[IM_User].ID
where [ReceiveUserID]=@UserID and State=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_TalkInfo> list = new List<IM_TalkInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_TalkInfo model = new IM_TalkInfo();
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
                    if (row["ReceiveUserID"] != null && row["ReceiveUserID"].ToString() != "")
                    {
                        model.ReceiveUserID = new Guid(row["ReceiveUserID"].ToString());
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

                    if (row["SendUserName"] != null && row["SendUserName"].ToString() != "")
                    {
                        model.SendUserName = row["SendUserName"].ToString();
                    }
                    //if (row["ReceiveUserName"] != null && row["ReceiveUserName"].ToString() != "")
                    //{
                    //    model.ReceiveUserName = row["ReceiveUserName"].ToString();
                    //}
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获取聊天信息
        /// <param name="sendUserID">sendUserID</param>
        /// <param name="receiveUserID">receiveUserID</param>
        /// <param name="state">state</param>
        /// </summary>
        public List<IM_TalkInfo> GetList(Guid sendUserID, Guid receiveUserID, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select [IM_Talk].*,UserName as SendUserName from [dbo].[IM_Talk]
inner join [dbo].[IM_User]
on [IM_Talk].[SendUserID]=[IM_User].ID
where [ReceiveUserID]=@ReceiveUserID and SendUserID=@SendUserID and State=@State ");
            SqlParameter[] parameters = {
					new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = sendUserID;
            parameters[1].Value = receiveUserID;
            parameters[2].Value = state;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<IM_TalkInfo> list = new List<IM_TalkInfo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                IM_TalkInfo model = new IM_TalkInfo();
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
                    if (row["ReceiveUserID"] != null && row["ReceiveUserID"].ToString() != "")
                    {
                        model.ReceiveUserID = new Guid(row["ReceiveUserID"].ToString());
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

                    if (row["SendUserName"] != null && row["SendUserName"].ToString() != "")
                    {
                        model.SendUserName = row["SendUserName"].ToString();
                    }
                    //if (row["ReceiveUserName"] != null && row["ReceiveUserName"].ToString() != "")
                    //{
                    //    model.ReceiveUserName = row["ReceiveUserName"].ToString();
                    //}
                }
                list.Add(model);
            }
            return list;
        }
        #endregion  ExtensionMethod
    }
}

