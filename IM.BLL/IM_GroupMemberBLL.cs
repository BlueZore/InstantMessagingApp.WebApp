using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;//Please add references
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// 群成员
    /// </summary>
    public partial class IM_GroupMemberBLL
    {
        private IM_GroupMemberDAL dal = new IM_GroupMemberDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_GroupMemberInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IM_GroupMemberInfo model)
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
        public IM_GroupMemberInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_GroupMemberInfo> GetList(QueryBuilder queryBuilder)
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
        /// 获取组成员
        /// <param name="userID"></param>
        /// </summary>
        public List<IM_GroupMemberInfo> GetListAllMenberForUser(Guid userID)
        {
            return dal.GetListAllMenberForUser(userID);
        }

        /// <summary>
        /// 获取群内成员
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// </summary>
        public List<IM_GroupMemberInfo> GetListForMenber(Guid userID, Guid groupID)
        {
            return dal.GetListForMenber(userID, groupID);
        }

        /// <summary>
        /// 删除成员
        /// <param name="userID">userID</param>
        /// <param name="groupID">groupID</param>
        /// </summary>
        public bool Delete(Guid userID, Guid groupID)
        {
            return dal.Delete(userID, groupID);
        }
        #endregion  ExtensionMethod
    }
}

