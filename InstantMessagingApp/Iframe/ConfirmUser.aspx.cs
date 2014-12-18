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
    public partial class ConfirmUser : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                IM_NewsInfo newModel = new IM_NewsBLL().GetModel(new Guid(id));
                lbNews.Text = newModel.Note;

                QueryBuilder queryBuilder = new QueryBuilder();
                queryBuilder.AddFilter("UserID", "=", newModel.ReceiveUserID.ToString());
                queryBuilder.AddOrderASC("CreateDate");
                ddlTeam.DataTextField = "TeamName";
                ddlTeam.DataValueField = "ID";
                ddlTeam.DataSource = new IM_TeamBLL().GetList(queryBuilder);
                ddlTeam.DataBind();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            new IM_NewsBLL().UpdateForState(new Guid(id), 4);

            IM_NewsInfo newModel = new IM_NewsBLL().GetModel(new Guid(id));

            IM_TeamMemberBLL teamMemberBLL = new IM_TeamMemberBLL();

            //当前用户添加对方
            IM_TeamMemberInfo teamMemberModel = new IM_TeamMemberInfo();
            teamMemberModel.TeamID = new Guid(ddlTeam.SelectedValue);
            teamMemberModel.UserID = newModel.SendUserID;
            teamMemberBLL.Add(teamMemberModel);

            //对方添加当前用户
            teamMemberModel = new IM_TeamMemberInfo();
            teamMemberBLL.AddForSendUser(newModel.SendUserID, userInfo.UserID);

            btnOK.Enabled = ddlTeam.Enabled = btnReject.Enabled = false;

            IM_UserInfo userModel = new IM_UserBLL().GetModel(newModel.SendUserID);

            ClientScript.RegisterStartupScript(this.GetType(), "JS", "<script>window.onload = function () { window.parent.window.addUserForTeam('" + newModel.SendUserID.ToString() + "','" + ddlTeam.SelectedValue + "','" + userModel.UserName + "','" + (string.IsNullOrEmpty(userModel.Pic) ? "/UserPic/default.jpg" : userModel.Pic) + "');};</script>");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            new IM_NewsBLL().UpdateForState(new Guid(ID), 3);

            btnOK.Enabled = ddlTeam.Enabled = btnReject.Enabled = false;
        }
    }
}