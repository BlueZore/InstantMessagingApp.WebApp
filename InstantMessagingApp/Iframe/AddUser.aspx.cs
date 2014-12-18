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
    public partial class AddUser : BasePager
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            gv.DataSource = new IM_UserBLL().GetListForNoAddUser(userInfo.UserID, txtUserName.Text);
            gv.DataBind();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arr = e.CommandArgument.ToString().Split('|');
            IM_NewsInfo newModel = new IM_NewsInfo();
            newModel.SendUserID = userInfo.UserID;
            newModel.ReceiveUserID = new Guid(arr[0]);
            newModel.BusinessType = 1;
            newModel.BusinessID = arr[0];
            newModel.Note = "用户\"" + userInfo.UserName + "\"提出添加申请!";
            newModel.State = 0;
            new IM_NewsBLL().Add(newModel);
            lbError.Text = "已发出申请";
        }
    }
}