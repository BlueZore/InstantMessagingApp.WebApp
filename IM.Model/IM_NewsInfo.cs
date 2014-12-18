using System;

namespace IM.Model
{
    /// <summary>
    /// 消息
    /// </summary>
    [Serializable]
    public partial class IM_NewsInfo
    {
        public IM_NewsInfo()
        { }
        #region Model

        public static string IM_News_Table = "IM_News";
        public static string ID_Field = "ID";
        public static string SendUserID_Field = "SendUserID";
        public static string ReceiveUserID_Field = "ReceiveUserID";
        public static string BusinessType_Field = "BusinessType";
        public static string BusinessID_Field = "BusinessID";
        public static string Note_Field = "Note";
        public static string State_Field = "State";
        public static string CreateDate_Field = "CreateDate";

        private Guid _id;
        private Guid _senduserid;
        private Guid _receiveuserid;
        private int? _businesstype;
        private string _businessid;
        private string _note;
        private int? _state;
        private DateTime? _createdate = DateTime.Now;

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
        /// 接收用户
        /// </summary>
        public Guid ReceiveUserID
        {
            set { _receiveuserid = value; }
            get { return _receiveuserid; }
        }

        /// <summary>
        /// 1用户添加，2群添加，3申请加入群
        /// </summary>
        public int? BusinessType
        {
            set { _businesstype = value; }
            get { return _businesstype; }
        }

        /// <summary>
        /// 业务ID
        /// </summary>
        public string BusinessID
        {
            set { _businessid = value; }
            get { return _businessid; }
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
        /// 0未查看，1已提示，2查看，3拒绝，4通过
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

        #endregion Model

    }
}

