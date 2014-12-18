using System;
namespace IM.Model
{
    /// <summary>
    /// 群
    /// </summary>
    [Serializable]
    public partial class IM_GroupInfo
    {
        public IM_GroupInfo()
        { }
        #region Model

        public static string IM_Group_Table = "IM_Group";
        public static string ID_Field = "ID";
        public static string UserID_Field = "UserID";
        public static string GroupName_Field = "GroupName";
        public static string OrderIndex_Field = "OrderIndex";
        public static string CreateDate_Field = "CreateDate";

        private Guid _id;
        private Guid _userid;
        private string _groupname;
        private int? _orderindex;
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
        /// 
        /// </summary>
        public Guid UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 群名称
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
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
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        #endregion Model

    }
}

