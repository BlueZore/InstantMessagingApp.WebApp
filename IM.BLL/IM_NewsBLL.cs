using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;//Please add references
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// 消息
    /// </summary>
    public partial class IM_NewsBLL
    {
        private IM_NewsDAL dal = new IM_NewsDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_NewsInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// <param name="ID">ID</param>
        /// <param name="state">state</param>
        /// </summary>
        public bool UpdateForState(Guid ID, int state)
        {
            return dal.UpdateForState(ID, state);
        }

        /// <summary>
        /// 删除一条数据
        /// <param name="ID">ID</param>
        /// </summary>
        public bool Delete(Guid ID)
        {

            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// <param name="ID">ID</param>
        /// </summary>
        public IM_NewsInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_NewsInfo> GetList(QueryBuilder queryBuilder)
        {
            return dal.GetList(queryBuilder);
        }

        /// <summary>
        /// 分页获取数据列表
        /// <param name="queryBuilder"></param>
        /// <param name="iRecordCount"></param>
        /// </summary>
        public DataTable GetListByPage(QueryBuilder queryBuilder, ref int iRecordCount)
        {
            return dal.GetListByPage(queryBuilder, ref iRecordCount);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页获取数据列表
        /// <param name="userID"></param>
        /// <param name="queryBuilder"></param>
        /// <param name="iRecordCount"></param>
        /// </summary>
        public DataTable GetListByPage(string userID, QueryBuilder queryBuilder, ref int iRecordCount)
        {
            return dal.GetListByPage(userID, queryBuilder, ref  iRecordCount);
        }
        #endregion  ExtensionMethod
    }
}

