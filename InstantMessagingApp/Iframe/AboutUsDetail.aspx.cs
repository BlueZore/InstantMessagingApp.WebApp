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
    public partial class AboutUsDetail : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IM_AboutUsInfo aboutUsModel = new IM_AboutUsBLL().GetModel(new Guid(Request["ID"]));
                lbTilte.Text = aboutUsModel.Title;
                lbNote.Text = aboutUsModel.Note;
            }
        }
    }
}