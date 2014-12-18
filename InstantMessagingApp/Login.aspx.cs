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
    public partial class Login : BasePager
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlUser.DataTextField = "UserName";
                ddlUser.DataValueField = "ID";
                QueryBuilder queryBuilder = new QueryBuilder();
                queryBuilder.AddOrderASC("UserName");
                ddlUser.DataSource = new IM_UserBLL().GetList(queryBuilder);
                ddlUser.DataBind();
                //if (!string.IsNullOrEmpty(Request["UserID"]))
                //{
                //    _FWCookieAdd(CookieName, Request["UserID"], 0, false);
                //    Session[CookieName] = null;
                //    Response.Redirect("~/Index.aspx");
                //}
            }
        }

        protected override void OnInit(EventArgs e) { }

        protected void bntLine_Click(object sender, EventArgs e)
        {
            _FWCookieAdd(CookieName, ddlUser.SelectedValue, 0, false);
            Session[CookieName] = null;
            Response.Redirect("~/Index.aspx");
        }
    }
}