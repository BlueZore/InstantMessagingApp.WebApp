using System;
namespace IM.Model
{
    /// <summary>
    /// 用户组
    /// </summary>
    [Serializable]
    public partial class IM_TeamInfo
    {
        public IM_TeamInfo()
        { }
        #region Model

        public static string IM_Team_Table = "IM_Team";
        public static string ID_Field = "ID";
        public static string UserID_Field = "UserID";
        public static string TeamName_Field = "TeamName";
        public static string OrderIndex_Field = "OrderIndex";
        public static string CreateDate_Field = "CreateDate";

        private Guid _id;
        private Guid _userid;
        private string _teamname;
        private int? _orderindex;
        private DateTime? _createdate;

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
        /// 组名称
        /// </summary>
        public string TeamName
        {
            set { _teamname = value; }
            get { return _teamname; }
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

