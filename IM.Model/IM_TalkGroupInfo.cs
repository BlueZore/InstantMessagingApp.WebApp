using System;
namespace IM.Model
{
    /// <summary>
    /// IM_TalkGroup:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class IM_TalkGroupInfo
    {
        public IM_TalkGroupInfo()
        { }
        #region Model

        public static string IM_TalkGroup_Table = "IM_TalkGroup";
        public static string ID_Field = "ID";
        public static string SendUserID_Field = "SendUserID";
        public static string GroupID_Field = "GroupID";
        public static string Note_Field = "Note";
        public static string Type_Field = "Type";
        public static string State_Field = "State";
        public static string CreateDate_Field = "CreateDate";
        public static string UserName_Field = "UserName";
        public static string GroupName_Field = "GroupName";

        private Guid _id;
        private Guid _senduserid;
        private Guid _groupid;
        private string _note;
        private int? _type;
        private int? _state;
        private DateTime? _createdate = DateTime.Now;
        private string _username;
        private string _groupname;

        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 发送用户
        /// </summary>
        public Guid SendUserID
        {
            set { _senduserid = value; }
            get { return _senduserid; }
        }

        /// <summary>
        /// 接收群
        /// </summary>
        public Guid GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }

        /// <summary>
        /// 0聊天，1文件
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }

        /// <summary>
        /// 0未查看，1查看，2拒绝，3通过
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
        /// 用户名
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }

        #endregion Model

    }
}

