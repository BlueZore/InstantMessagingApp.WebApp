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
    public partial class GroupView : BasePager
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
            if (!IsPostBack)
            {
                QueryBuilder queryBuilder = new QueryBuilder();
                queryBuilder.AddFilter(IM_GroupInfo.UserID_Field, "=", userInfo.UserID.ToString());
                queryBuilder.AddOrderASC(IM_GroupInfo.GroupName_Field);
                ddlGroup.DataTextField = IM_GroupInfo.GroupName_Field;
                ddlGroup.DataValueField = IM_GroupInfo.ID_Field;
                ddlGroup.DataSource = new IM_GroupBLL().GetList(queryBuilder);
                ddlGroup.DataBind();
            }
        }


        protected void btnLock_Click(object sender, EventArgs e)
        {
            if (ddlGroup.Items.Count > 0)
            {
                gv.DataSource = new IM_UserBLL().GetListForNoAddGroup(userInfo.UserID, new Guid(ddlGroup.SelectedValue));
                gv.DataBind();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewGroup.aspx");
        }


        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arr = e.CommandArgument.ToString().Split('|');
            IM_NewsInfo newModel = new IM_NewsInfo();
            newModel.SendUserID = userInfo.UserID;
            newModel.ReceiveUserID = new Guid(arr[0]);
            newModel.BusinessType = 2;
            newModel.BusinessID = ddlGroup.SelectedValue;
            newModel.Note = "群\"" + ddlGroup.SelectedItem.Text + "\"提出添加申请!";
            newModel.State = 0;
            new IM_NewsBLL().Add(newModel);
            lbError.Text = "已发出申请";
        }

    }
}