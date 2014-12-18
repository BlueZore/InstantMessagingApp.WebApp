using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using XSAT.Lib2014.System.Common;
using XSAT.Lib2014.System.Data;
using IM.Model;
using IM.BLL;
using System.Web.UI.HtmlControls;

namespace InstantMessagingApp
{
    /// <summary>
    /// 基页
    /// </summary>
    public class BasePager : BasePage
    {
        #region 用户
        public string CookieName = "IM_User";

        public UserInfo userInfo
        {
            get;
            set;
        }

        protected override void OnInit(EventArgs e)
        {
            if (Session[CookieName] == null)
            {
                if (!(_FWCookieRegex(CookieName) && ExePow(Request.Cookies[CookieName].Value)))
                {
                    MessageBox.ShowAndRedirect(this, "存在安全问题！", "/Error.html");
                }
            }
            else
            {
                userInfo = (UserInfo)Session[CookieName];
            }
        }

        /// <summary>
        /// 执行权限验证
        /// </summary>
        /// <param name="value">登录信息表ID</param>
        bool ExePow(string value)
        {
            try
            {
                IM_UserInfo userModel = new IM_UserBLL().GetModel(new Guid(value));
                if (userModel != null)
                {
                    UserInfo ui = new UserInfo();
                    ui.UserID = userModel.ID;
                    ui.UserName = userModel.UserName;
                    userInfo = ui;
                    Session[CookieName] = ui;
                    return true;
                }
            }
            catch { }
            return false;
        }
        #endregion
    }

    public class UserInfo
    {
        public Guid UserID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
    }
}