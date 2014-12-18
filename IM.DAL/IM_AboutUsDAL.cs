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
    /// 数据访问类:IM_AboutUsDAL
    /// </summary>
    public partial class IM_AboutUsDAL
    {
        public IM_AboutUsDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_AboutUsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("insert into IM_AboutUs(");
            strSql.Append("ID,Title,Note,IsDelete,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Title,@Note,@IsDelete,@CreateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Note", SqlDbType.NVarChar),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[n++].Value = Guid.NewGuid();
            parameters[n++].Value = model.Title;
            parameters[n++].Value = model.Note;
            parameters[n++].Value = model.IsDelete;
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
        public bool Update(IM_AboutUsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            int n = 0;
            strSql.Append("update IM_AboutUs set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Note=@Note,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Note", SqlDbType.NVarChar),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[n++].Value = model.Title;
            parameters[n++].Value = model.Note;
            parameters[n++].Value = model.IsDelete;
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
            strSql.Append("update IM_AboutUs set IsDelete=1 ");
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
        public IM_AboutUsInfo GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Title,Note,IsDelete,CreateDate from IM_AboutUs ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            IM_AboutUsInfo model = new IM_AboutUsInfo();
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
        public IM_AboutUsInfo DataRowToModel(DataRow row)
        {
            IM_AboutUsInfo model = new IM_AboutUsInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
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
        public List<IM_AboutUsInfo> GetList(QueryBuilder queryBuilder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (queryBuilder.Top > 0)
            {
                strSql.Append(" top " + queryBuilder.Top);
            }
            strSql.Append(" ID,Title,Note,IsDelete,CreateDate ");
            strSql.Append(" FROM IM_AboutUs ");
            strSql.Append(queryBuilder.Where);
            strSql.Append(queryBuilder.Order);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<IM_AboutUsInfo> list = new List<IM_AboutUsInfo>();
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
            sbSql.Append("SELECT * FROM IM_AboutUs" + queryBuilder.Where);
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
            DataSet ds = DbHelperSQL.RunProcedure("ExecutePaging", para, "IM_AboutUs");
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

        #endregion  ExtensionMethod
    }
}

