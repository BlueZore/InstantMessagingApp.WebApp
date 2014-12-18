using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;//Please add references
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// 单聊记录
    /// </summary>
    public partial class IM_TalkBLL
    {
        private IM_TalkDAL dal = new IM_TalkDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TalkInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IM_TalkInfo model)
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
        public IM_TalkInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_TalkInfo> GetList(QueryBuilder queryBuilder)
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
        /// 修改状态
        /// <param name="ID"></param>
        /// <param name="state"></param>
        /// </summary>
        public bool UpdateForState(Guid ID, int state)
        {
            return dal.UpdateForState(ID, state);
        }

        /// <summary>
        /// 获取聊天信息
        /// <param name="userID">userID</param>
        /// </summary>
        public List<IM_TalkInfo> GetList(Guid userID)
        {
            return dal.GetList(userID);
        }

        /// <summary>
        /// 获取聊天信息
        /// <param name="sendUserID">sendUserID</param>
        /// <param name="receiveUserID">receiveUserID</param>
        /// <param name="state">state</param>
        /// </summary>
        public List<IM_TalkInfo> GetList(Guid sendUserID, Guid receiveUserID, int state)
        {
            return dal.GetList(sendUserID, receiveUserID, state);
        }
        #endregion  ExtensionMethod
    }
}

