using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BLL;
using IM.Model;

namespace InstantMessagingApp
{
    public partial class NewGroup : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            IM_GroupInfo groupModel = new IM_GroupInfo();
            groupModel.ID = Guid.NewGuid();
            groupModel.GroupName = txtGroupName.Text;
            groupModel.UserID = userInfo.UserID;
            new IM_GroupBLL().Add(groupModel);
            IM_GroupMemberInfo groupMemberModel = new IM_GroupMemberInfo();
            groupMemberModel.ID = Guid.NewGuid();
            groupMemberModel.GroupID = groupModel.ID;
            groupMemberModel.UserID = groupModel.UserID;
            new IM_GroupMemberBLL().Add(groupMemberModel);
            txtGroupName.Text = string.Empty;
            lbError.Text = "完成添加";

            ClientScript.RegisterStartupScript(this.GetType(), "JS", "<script>window.onload = function () {window.parent.window.addGroup('" + groupModel.ID + "','" + groupModel.GroupName + "');};</script>");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroupView.aspx");
        }
    }
}