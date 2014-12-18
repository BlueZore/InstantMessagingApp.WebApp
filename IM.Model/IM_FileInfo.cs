using System;
namespace IM.Model
{
    /// <summary>
    /// IM_File:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class IM_FileInfo
    {
        public IM_FileInfo()
        { }
        #region Model

        public static string IM_File_Table = "IM_File";
        public static string ID_Field = "ID";
        public static string FileName_Field = "FileName";
        public static string FilePath_Field = "FilePath";
        public static string UserID_Field = "UserID";
        public static string ReceiveID_Field = "ReceiveID";
        public static string Type_Field = "Type";
        public static string CreateDate_Field = "CreateDate";

        private Guid _id;
        private string _filename;
        private string _filepath;
        private Guid _userid;
        private Guid _receiveid;
        private int? _type;
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
        /// 文件名
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }

        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }

        /// <summary>
        /// 所属用户
        /// </summary>
        public Guid UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid ReceiveID
        {
            set { _receiveid = value; }
            get { return _receiveid; }
        }

        /// <summary>
        /// 1聊天，2群
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
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

