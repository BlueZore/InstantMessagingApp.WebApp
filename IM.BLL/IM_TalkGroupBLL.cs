using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// IM_TalkGroup
    /// </summary>
    public partial class IM_TalkGroupBLL
    {
        private IM_TalkGroupDAL dal = new IM_TalkGroupDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TalkGroupInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IM_TalkGroupInfo model)
        {
            return dal.Update(model);
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
        public IM_TalkGroupInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_TalkGroupInfo> GetList(QueryBuilder queryBuilder)
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
        /// 获取群聊天信息
        /// <param name="userID">userID</param>
        /// </summary>
        public List<IM_TalkGroupInfo> GetList(Guid userID)
        {
            return dal.GetList(userID);
        }

        /// <summary>
        /// 获取未查看群聊信息
        /// <param name="groupID">groupID</param>
        /// <param name="userID">userID</param>
        /// </summary>
        public List<IM_TalkGroupInfo> GetList(Guid groupID, Guid userID)
        {
            return dal.GetList(groupID, userID);
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
            return dal.GetListByPage(groupID, userID, queryBuilder, ref iRecordCount);
        }
        #endregion  ExtensionMethod
    }
}

