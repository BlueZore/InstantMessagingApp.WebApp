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
    public partial class BaseUserView : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IM_UserInfo userModel = new IM_UserBLL().GetModel(new Guid(Request["UserID"]));
                lbUserName1.Text = lbUserName2.Text = userModel.UserName;
                imgPic.ImageUrl = "/UpLoadFiles" + (string.IsNullOrEmpty(userModel.Pic) ? "/UserPic/default.jpg" : userModel.Pic);
            }
        }
    }
}