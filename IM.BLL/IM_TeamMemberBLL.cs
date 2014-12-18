using System;
using System.Data;
using System.Collections.Generic;
using XSAT.Lib2014.System.Data;//Please add references
using IM.DAL;
using IM.Model;

namespace IM.BLL
{
    /// <summary>
    /// 用户组成员
    /// </summary>
    public partial class IM_TeamMemberBLL
    {
        private IM_TeamMemberDAL dal = new IM_TeamMemberDAL();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// <param name="model">实体</param>
        /// </summary>
        public bool Add(IM_TeamMemberInfo model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IM_TeamMemberInfo model)
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
        public IM_TeamMemberInfo GetModel(Guid ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="queryBuilder"></param>
        /// </summary>
        public List<IM_TeamMemberInfo> GetList(QueryBuilder queryBuilder)
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
        /// 增加一条数据
        /// <param name="sendUser">发送用户</param>
        /// <param name="currUser">当前用户</param>
        /// </summary>
        public bool AddForSendUser(Guid sendUser, Guid currUser)
        {
            return dal.AddForSendUser(sendUser, currUser);
        }

        /// <summary>
        /// 获取所有组中成员
        /// <param name="userID"></param>
        /// </summary>
        public List<IM_UserInfo> GetAllTeamMemberList(Guid userID)
        {
            return dal.GetAllTeamMemberList(userID);
        }

        /// <summary>
        /// 删除成员
        /// <param name="userID">userID</param>
        /// <param name="teamID">teamID</param>
        /// </summary>
        public bool Delete(Guid userID, Guid teamID)
        {
            return dal.Delete(userID, teamID);
        }

        /// <summary>
        /// 修改成员组
        /// <param name="teamID">实体</param>
        /// <param name="oldTeamID">实体</param>
        /// <param name="userID">实体</param>
        /// </summary>
        public bool Update(Guid teamID, Guid oldTeamID, Guid userID)
        {
            return dal.Update(teamID, oldTeamID, userID);
        }
        #endregion  ExtensionMethod
    }
}

