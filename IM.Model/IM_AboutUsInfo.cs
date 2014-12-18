using System;
namespace IM.Model
{
    /// <summary>
    /// 新闻表
    /// </summary>
    [Serializable]
    public partial class IM_AboutUsInfo
    {
        public IM_AboutUsInfo()
        { }
        #region Model

        public static string IM_AboutUs_Table = "IM_AboutUs";
        public static string ID_Field = "ID";
        public static string Title_Field = "Title";
        public static string Note_Field = "Note";
        public static string IsDelete_Field = "IsDelete";
        public static string CreateDate_Field = "CreateDate";

        private Guid _id;
        private string _title;
        private string _note;
        private int? _isdelete = 0;
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
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        /// 
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
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

