using System;
namespace IM.Model
{
    /// <summary>
    /// 用户组成员
    /// </summary>
    [Serializable]
    public partial class IM_TeamMemberInfo
    {
        public IM_TeamMemberInfo()
        { }
        #region Model

        public static string IM_TeamMember_Table = "IM_TeamMember";
        public static string ID_Field = "ID";
        public static string TeamID_Field = "TeamID";
        public static string UserID_Field = "UserID";
        public static string OrderIndex_Field = "OrderIndex";

        private Guid _id;
        private Guid _teamid;
        private Guid _userid;
        private int? _orderindex;

        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid TeamID
        {
            set { _teamid = value; }
            get { return _teamid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? OrderIndex
        {
            set { _orderindex = value; }
            get { return _orderindex; }
        }

        #endregion Model

    }
}

