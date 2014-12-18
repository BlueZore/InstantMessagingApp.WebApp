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
    public partial class MoveUser : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserID.Value = Request["UserID"];
                hidTeamID.Value = Request["TeamID"];
                lbUserName.Text = new IM_UserBLL().GetModel(new Guid(hidUserID.Value)).UserName;

                QueryBuilder queryBuilder = new QueryBuilder();
                queryBuilder.AddFilter(IM_TeamInfo.UserID_Field, "=", userInfo.UserID.ToString());
                queryBuilder.AddOrderASC(IM_TeamInfo.TeamName_Field);
                ddlTeam.DataTextField = "TeamName";
                ddlTeam.DataValueField = "ID";
                ddlTeam.DataSource = new IM_TeamBLL().GetList(queryBuilder);
                ddlTeam.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (new IM_TeamMemberBLL().Update(new Guid(ddlTeam.SelectedValue), new Guid(hidTeamID.Value), new Guid(hidUserID.Value)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "JS", "<script>window.onload = function () {window.parent.window.moveUser('" + ddlTeam.SelectedValue + "','" + hidUserID.Value + "');};</script>");
            }
            lbError.Text = "完成添加";
        }
    }
}