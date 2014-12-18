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
    public partial class AboutUsView : BasePager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder queryBuilder = new QueryBuilder();
                queryBuilder.AddOrderDESC(IM_AboutUsInfo.CreateDate_Field);
                rp.DataSource = new IM_AboutUsBLL().GetList(queryBuilder);
                rp.DataBind();
            }
        }
    }
}