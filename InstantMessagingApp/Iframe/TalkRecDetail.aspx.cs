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
    public partial class TalkRecDetail : BasePager
    {
        int iRecordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["ReceiveUserID"]))
                {
                    hidUserID.Value = userInfo.UserID.ToString();
                    hidReceiveUserID.Value = Request["ReceiveUserID"];
                    if (!string.IsNullOrEmpty(Request["ReceiveUserID"]) && Request["Type"] == "1")
                    {
                        hidReceiveUserName.Value = new IM_UserBLL().GetModel(new Guid(hidReceiveUserID.Value)).UserName;
                    }
                    Shunt();
                }
            }
        }

        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            Shunt();
        }

        void Shunt()
        {
            talkRP.Visible = talkGroupRP.Visible = newsRP.Visible = false;
            switch (Request["Type"])
            {
                case "1":
                    TalkBind();
                    break;
                case "2":
                    TalkGroupBind();
                    break;
                case "3":
                    NewsBind();
                    break;
            }
        }

        void TalkBind()
        {
            talkRP.Visible = true;
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.Where = " where (SendUserID='" + userInfo.UserID + "' and ReceiveUserID='" + hidReceiveUserID.Value + "') or (ReceiveUserID='" + userInfo.UserID + "' and SendUserID='" + hidReceiveUserID.Value + "')";
            queryBuilder.AddOrderDESC(IM_TalkInfo.CreateDate_Field);
            queryBuilder.PageIndex = Pager.CurrentPageIndex;
            talkRP.DataSource = new IM_TalkBLL().GetListByPage(queryBuilder, ref iRecordCount);
            talkRP.DataBind();
            Pager.RecordCount = iRecordCount;
        }

        void TalkGroupBind()
        {
            talkGroupRP.Visible = true;
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.AddOrderDESC(IM_TalkInfo.CreateDate_Field);
            queryBuilder.PageIndex = Pager.CurrentPageIndex;
            talkGroupRP.DataSource = new IM_TalkGroupBLL().GetListByPage(hidReceiveUserID.Value, hidUserID.Value, queryBuilder, ref iRecordCount);
            talkGroupRP.DataBind();
            Pager.RecordCount = iRecordCount;
        }

        void NewsBind()
        {
            newsRP.Visible = true;
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.AddOrderDESC(IM_TalkInfo.CreateDate_Field);
            queryBuilder.PageIndex = Pager.CurrentPageIndex;
            newsRP.DataSource = new IM_NewsBLL().GetListByPage(hidUserID.Value, queryBuilder, ref iRecordCount);
            newsRP.DataBind();
            Pager.RecordCount = iRecordCount;
        }
    }
}