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
    public partial class InitData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        protected void txtInit_Click(object sender, EventArgs e)
        {
            IM_UserInfo userModel = new IM_UserInfo();
            userModel.ID = Guid.NewGuid();
            userModel.IsDelete = 0;
            userModel.UserName = txtUserName.Text;

            IM_TeamInfo teamModel = new IM_TeamInfo();
            teamModel.ID = Guid.NewGuid();
            teamModel.TeamName = "好友";
            teamModel.UserID = userModel.ID;
            teamModel.CreateDate = DateTime.Now;

            new IM_UserBLL().Add(userModel);
            new IM_TeamBLL().Add(teamModel);

            lblResult.Text = "OK";

            DataBind();
        }

        public override void DataBind()
        {
            QueryBuilder querybuilder=new QueryBuilder();
            querybuilder.AddOrderDESC("UserName");
            gv.DataSource = new IM_UserBLL().GetList(querybuilder);
            gv.DataBind();
        }
    }
}