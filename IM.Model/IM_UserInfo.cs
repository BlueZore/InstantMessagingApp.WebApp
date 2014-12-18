using System;
namespace IM.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    [Serializable]
    public partial class IM_UserInfo
    {
        public IM_UserInfo()
        { }
        #region Model

        public static string IM_User_Table = "IM_User";
        public static string ID_Field = "ID";
        public static string Sys_UserID_Field = "Sys_UserID";
        public static string UserName_Field = "UserName";
        public static string Pic_Field = "Pic";
        public static string LoginDate_Field = "LoginDate";
        public static string LastDate_Field = "LastDate";
        public static string IsDelete_Field = "IsDelete";

        public static string TeamID_Field = "TeamID";
        public static string TeamName_Field = "TeamName";
        public static string State_Field = "State";

        private Guid _id;
        private string _sys_userid;
        private string _username;
        private string _pic;
        private DateTime? _logindate;
        private DateTime? _lastdate;
        private int? _isdelete;

        private Guid _teamid;
        private string _teamname;
        private int? _state;

        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 对应系统用户ID
        /// </summary>
        public string Sys_UserID
        {
            set { _sys_userid = value; }
            get { return _sys_userid; }
        }

        /// <summary>
        /// 用户名
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

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LoginDate
        {
            set { _logindate = value; }
            get { return _logindate; }
        }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? LastDate
        {
            set { _lastdate = value; }
            get { return _lastdate; }
        }

        /// <summary>
        /// 0存在，1删除
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
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
        public string TeamName
        {
            set { _teamname = value; }
            get { return _teamname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}

