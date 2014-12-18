using System;
namespace IM.Model
{
    /// <summary>
    /// 群成员
    /// </summary>
    [Serializable]
    public partial class IM_GroupMemberInfo
    {
        public IM_GroupMemberInfo()
        { }
        #region Model

        public static string IM_GroupMember_Table = "IM_GroupMember";
        public static string ID_Field = "ID";
        public static string GroupID_Field = "GroupID";
        public static string UserID_Field = "UserID";
        public static string OrderIndex_Field = "OrderIndex";
        public static string UserName_Field = "UserName";
        public static string Pic_Field = "Pic";

        private Guid _id;
        private Guid _groupid;
        private Guid _userid;
        private int? _orderindex;
        private string _username;
        private string _pic;

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
        public Guid GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
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

        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// 头像
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        #endregion Model

    }
}

