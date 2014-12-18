using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class IM_UserBLL
    {
        private IM_UserDAL dal = new IM_UserDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_UserInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IM_UserInfo model)
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
        public IM_UserInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// <param name="sys_UserID">sys_UserID</param>
        /// </summary>
        public IM_UserInfo GetModel(string sys_UserID)
        {

            return dal.GetModel(sys_UserID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_UserInfo> GetList(QueryBuilder queryBuilder)
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
        /// 获取未添加用户
        /// <param name="ID"></param>
        /// <param name="userName"></param>
        /// </summary>
        public List<IM_UserInfo> GetListForNoAddUser(Guid ID, string userName)
        {
            return dal.GetListForNoAddUser(ID, userName);
        }

        /// <summary>
        /// 获取未添加用户
        /// <param name="userID"></param>
        /// <param name="groupID"></param>
        /// </summary>
        public List<IM_UserInfo> GetListForNoAddGroup(Guid userID, Guid groupID)
        {
            return dal.GetListForNoAddGroup(userID, groupID);
        }
        #endregion  ExtensionMethod
    }
}

