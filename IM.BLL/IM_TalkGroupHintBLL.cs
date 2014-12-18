using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;//Please add references
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// 群聊消息提醒
    /// </summary>
    public partial class IM_TalkGroupHintBLL
    {
        private IM_TalkGroupHintDAL dal = new IM_TalkGroupHintDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TalkGroupHintInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IM_TalkGroupHintInfo model)
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
        public IM_TalkGroupHintInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_TalkGroupHintInfo> GetList(QueryBuilder queryBuilder)
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
        /// <param name="ID">实体</param>
        /// <param name="State">实体</param>
        /// </summary>
        public bool UpdateForState(Guid talkGroupID, Guid userID, int state)
        {
            return dal.UpdateForState(talkGroupID, userID, state);
        }
        #endregion  ExtensionMethod
    }
}

