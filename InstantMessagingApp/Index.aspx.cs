using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BLL;
using IM.Model;
using XSAT.Lib2014.System.Data;

namespace InstantMessagingApp
{
    public partial class Index : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IM_UserInfo userModel = new IM_UserBLL().GetModel(userInfo.UserID);
                divSelfName.InnerHtml = userModel.UserName;
                imgSelfUserPic.ImageUrl = "~/UpLoadFiles" + (string.IsNullOrEmpty(userModel.Pic) ? "/UserPic/default.jpg" : userModel.Pic);
                hidID.Value = userModel.ID.ToString();

                LoadTeamAndUser();
                LoadGroupAndUser();
            }
        }

        private void LoadTeamAndUser()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.AddFilter("UserID", "=", userInfo.UserID.ToString());
            queryBuilder.AddOrderASC("CreateDate");
            List<IM_TeamInfo> teamList = new IM_TeamBLL().GetList(queryBuilder);
            List<IM_UserInfo> userList = new IM_TeamMemberBLL().GetAllTeamMemberList(userInfo.UserID);

            string teamHtml = "";

            foreach (IM_TeamInfo teamModel in teamList)
            {
                teamHtml += @"
<div class='team_item'>
    <div class='team_item_info' tID='" + teamModel.ID + @"'>
        <img src='/Image/sanjian.png' />
        <span>" + teamModel.TeamName + @"</span>
    </div>
    <ul class='team_user'>
";
                var tmpList = userList.Where(p => p.TeamID == teamModel.ID);
                foreach (var item in tmpList)
                {
                    teamHtml += @"
        <li uID='" + item.ID + @"'>
            <img src='" + ("/UpLoadFiles" + (string.IsNullOrEmpty(item.Pic) ? "/UserPic/default.jpg" : item.Pic)) + @"' width='17px' height='17' />
            <span>" + item.UserName + @"</span>
        </li>
";
                }

                teamHtml += @"
    </ul>
</div>
";
            }
            TeamListDIV.InnerHtml = teamHtml;
        }

        private void LoadGroupAndUser()
        {
            List<IM_GroupInfo> groupList = new IM_GroupBLL().GetListGroupForUser(userInfo.UserID);
            List<IM_GroupMemberInfo> groupMemberList = new IM_GroupMemberBLL().GetListAllMenberForUser(userInfo.UserID);


            string groupHtml = "";

            foreach (IM_GroupInfo groupModel in groupList)
            {
                groupHtml += @"
<div class='team_item'>
    <div class='team_item_info' gID='" + groupModel.ID + @"'>
        <img src='Image/leftmenu2.png' style='margin-top: 3px;' />
        <span>" + groupModel.GroupName + @"</span>
    </div>
    <ul class='team_user'>
";
//                var tmpList = groupMemberList.Where(p => p.GroupID == groupModel.ID);
//                foreach (var item in tmpList)
//                {
//                    groupHtml += @"
//        <li uID='" + item.UserID + @"'>
//            <img src='" + ("/UpLoadFiles" + (string.IsNullOrEmpty(item.Pic) ? "/UserPic/default.jpg" : item.Pic)) + @"' width='17px' height='17' />
//            <span>" + item.UserName + @"</span>
//        </li>
//";
//                }

                groupHtml += @"
    </ul>
</div>
";
            }
            GroupListDIV.InnerHtml = groupHtml;
        }

        protected void bntLine_Click(object sender, EventArgs e)
        {
            _FWCookieAdd(CookieName, hidID.Value, 0, true);
        }


    }
}