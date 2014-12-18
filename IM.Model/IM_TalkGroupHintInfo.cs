using System;
namespace IM.Model
{
    /// <summary>
    /// 群聊消息提醒
    /// </summary>
    [Serializable]
    public partial class IM_TalkGroupHintInfo
    {
        public IM_TalkGroupHintInfo()
        { }
        #region Model

        public static string IM_TalkGroupHint_Table = "IM_TalkGroupHint";
        public static string ID_Field = "ID";
        public static string GroupID_Field = "GroupID";
        public static string TalkGroupID_Field = "TalkGroupID";
        public static string UserID_Field = "UserID";
        public static string State_Field = "State";

        private Guid _id;
        private Guid _groupid;
        private Guid _talkgroupid;
        private Guid _userid;
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
        public Guid TalkGroupID
        {
            set { _talkgroupid = value; }
            get { return _talkgroupid; }
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
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }

        #endregion Model

    }
}

