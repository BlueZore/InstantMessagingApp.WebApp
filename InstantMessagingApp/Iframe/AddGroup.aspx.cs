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
    public partial class AddGroup : BasePager
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            gv.DataSource = new IM_GroupBLL().GetListForNoAddGroup(userInfo.UserID, txtGroupName.Text);
            gv.DataBind();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arr = e.CommandArgument.ToString().Split('|');
            IM_NewsInfo newModel = new IM_NewsInfo();
            newModel.SendUserID = userInfo.UserID;
            newModel.ReceiveUserID = new Guid(arr[1]);
            newModel.BusinessType = 3;
            newModel.BusinessID = arr[0];
            newModel.Note = "用户\"" + userInfo.UserName + "\"申请加入\"" + arr[2] + "\"群!";
            newModel.State = 0;
            new IM_NewsBLL().Add(newModel);
            lbError.Text = "已发出申请";
        }
    }
}