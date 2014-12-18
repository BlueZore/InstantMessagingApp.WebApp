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
    public partial class TalkRecView : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<IM_UserInfo> userList = new IM_TeamMemberBLL().GetAllTeamMemberList(userInfo.UserID);
                TreeData.Value = "{ id: '1', pId:'0', name: '好友', open: true, icon:'/JS/zTree/img/diy/1_open.png' }";
                foreach (IM_UserInfo userModel in userList)
                {
                    TreeData.Value += ",{ id: '" + userModel.ID + "',pId:'1', name: '" + userModel.UserName + "', icon:'/JS/zTree/img/diy/2.png' }";
                }

                List<IM_GroupInfo> groupList = new IM_GroupBLL().GetListGroupForUser(userInfo.UserID);
                TreeData.Value += ",{ id: '2', pId:'0', name: '群', icon:'/JS/zTree/img/diy/1_open.png' }";
                foreach (IM_GroupInfo groupModel in groupList)
                {
                    TreeData.Value += ",{ id: '" + groupModel.ID + "',pId:'2', name: '" + groupModel.GroupName + "', icon:'/JS/zTree/img/diy/2.png' }";
                }

                TreeData.Value += ",{ id: '3', pId:'0', name: ' 消息', icon:'/JS/zTree/img/diy/1_open.png' }";
                TreeData.Value += ",{ id: '30',pId:'3', name: '通知', icon:'/JS/zTree/img/diy/2.png' }";


                TreeData.Value = "[" + TreeData.Value + "]";
            }
        }
    }
}