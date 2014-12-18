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
    public partial class ConfirmGroup : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                IM_NewsInfo newModel = new IM_NewsBLL().GetModel(new Guid(id));
                lbNews.Text = newModel.Note;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            new IM_NewsBLL().UpdateForState(new Guid(id), 4);

            IM_NewsInfo newModel = new IM_NewsBLL().GetModel(new Guid(id));

            IM_GroupMemberBLL groupMemberBLL = new IM_GroupMemberBLL();

            //当前用户添加对方
            IM_GroupMemberInfo groupMemberModel = new IM_GroupMemberInfo();
            groupMemberModel.ID = Guid.NewGuid();
            groupMemberModel.GroupID = new Guid(newModel.BusinessID);
            groupMemberModel.UserID = newModel.BusinessType == 3 ? newModel.SendUserID : newModel.ReceiveUserID;//3为申请加入，所以添加发送方
            groupMemberBLL.Add(groupMemberModel);

            btnOK.Enabled = btnReject.Enabled = false;

            IM_GroupInfo groupModel = new IM_GroupBLL().GetModel(groupMemberModel.GroupID);

            ClientScript.RegisterStartupScript(this.GetType(), "JS", "<script>window.onload = function () {window.parent.window.addGroup('" + groupMemberModel.GroupID + "','" + groupModel.GroupName + "');};</script>");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            new IM_NewsBLL().UpdateForState(new Guid(ID), 3);

            btnOK.Enabled = btnReject.Enabled = false;
        }
    }
}