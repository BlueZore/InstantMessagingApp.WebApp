using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IM.BLL;
using IM.Model;
using XSAT.Lib2014.System.Data;
using Newtonsoft.Json;

namespace InstantMessagingApp
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class Ajax : System.Web.Services.WebService
    {
        /// <summary>
        /// 获取提示信息
        /// {NewsList:[{"ID":1,"Name":"23"},{"ID":1,"Name":"23"}]}
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [WebMethod]
        public string getUserAboutNews(string UserID)
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            string json = "";

            //添加好友提示
            queryBuilder.AddFilter("ReceiveUserID", "=", UserID);
            //queryBuilder.AddFilter("BusinessType", "=", "1");
            queryBuilder.AddFilter("State", "=", "0");
            queryBuilder.AddOrderASC("CreateDate");
            IM_NewsBLL newsBLL = new IM_NewsBLL();
            List<IM_NewsInfo> newsList = newsBLL.GetList(queryBuilder);
            string jsonItem = "";
            foreach (IM_NewsInfo newsModel in newsList)
            {
                newsBLL.UpdateForState(newsModel.ID, 1);
                jsonItem += ",{";
                jsonItem += "ID:'" + newsModel.ID + "'";
                jsonItem += ",SendUserID:'" + newsModel.SendUserID + "'";
                jsonItem += ",ReceiveUserID:'" + newsModel.ReceiveUserID + "'";
                jsonItem += ",BusinessType:'" + (newsModel.BusinessType == 3 ? 2 : newsModel.BusinessType) + "'";//修改加入群
                jsonItem += ",Note:'" + newsModel.Note + "'";
                jsonItem += "}";
            }
            json = "NewsList:[" + (jsonItem.Length == 0 ? "" : jsonItem.Substring(1)) + "]";

            //单聊提示
            jsonItem = "";
            IM_TalkBLL talkBLL = new IM_TalkBLL();
            List<IM_TalkInfo> talkList = talkBLL.GetList(new Guid(UserID));
            foreach (IM_TalkInfo talkModel in talkList)
            {
                talkBLL.UpdateForState(talkModel.ID, 1);
                jsonItem += ",{";
                jsonItem += "ID:'" + talkModel.ID + "'";
                jsonItem += ",SendUserName:'" + talkModel.SendUserName + "'";
                jsonItem += ",SendUserID:'" + talkModel.SendUserID + "'";
                jsonItem += ",Note:'" + talkModel.Note + "'";
                jsonItem += ",Type:'" + talkModel.Type + "'";
                jsonItem += ",CreateDate:'" + talkModel.CreateDate + "'";
                jsonItem += "}";
            }
            json += ",TalkList:[" + (jsonItem.Length == 0 ? "" : jsonItem.Substring(1)) + "]";

            //群聊提示
            jsonItem = "";
            IM_TalkGroupBLL talkGroupBLL = new IM_TalkGroupBLL();
            IM_TalkGroupHintBLL talkGroupHintBLL = new IM_TalkGroupHintBLL();
            List<IM_TalkGroupInfo> talkGroupList = talkGroupBLL.GetList(new Guid(UserID));
            foreach (IM_TalkGroupInfo talkGroupModel in talkGroupList)
            {
                talkGroupHintBLL.UpdateForState(talkGroupModel.ID, new Guid(UserID), 1);
                jsonItem += ",{";
                jsonItem += "ID:'" + talkGroupModel.ID + "'";
                jsonItem += ",GroupName:'" + talkGroupModel.GroupName + "'";
                jsonItem += ",GroupID:'" + talkGroupModel.GroupID + "'";
                jsonItem += ",UserName:'" + talkGroupModel.UserName + "'";
                jsonItem += ",Note:'" + talkGroupModel.Note + "'";
                jsonItem += ",Type:'" + talkGroupModel.Type + "'";
                jsonItem += ",CreateDate:'" + talkGroupModel.CreateDate + "'";
                jsonItem += "}";
            }
            json += ",TalkGroupList:[" + (jsonItem.Length == 0 ? "" : jsonItem.Substring(1)) + "]";

            json = "[{" + json + "}]";



            return json;
        }

        /// <summary>
        /// 发送聊天内容
        /// </summary>
        /// <param name="SendUserID"></param>
        /// <param name="ReceiveUserID"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [WebMethod]
        public string sendUserTalk(string SendUserID, string ReceiveUserID, string Type, string Note)
        {
            switch (Type)
            {
                case "1":
                    IM_TalkInfo talkModel = new IM_TalkInfo();
                    talkModel.SendUserID = new Guid(SendUserID);
                    talkModel.ReceiveUserID = new Guid(ReceiveUserID);
                    talkModel.Note = Note;
                    talkModel.Type = 0;
                    talkModel.State = 0;
                    new IM_TalkBLL().Add(talkModel);
                    return DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                case "2"://ReceiveUserID为GroupID
                    IM_TalkGroupInfo talkGroupModel = new IM_TalkGroupInfo();
                    talkGroupModel.ID = Guid.NewGuid();
                    talkGroupModel.SendUserID = new Guid(SendUserID);
                    talkGroupModel.GroupID = new Guid(ReceiveUserID);
                    talkGroupModel.Note = Note;
                    talkGroupModel.Type = 0;
                    new IM_TalkGroupBLL().Add(talkGroupModel);

                    QueryBuilder queryBuilder = new QueryBuilder();
                    queryBuilder.AddFilter(IM_GroupMemberInfo.GroupID_Field, "=", ReceiveUserID);
                    List<IM_GroupMemberInfo> groupMemberList = new IM_GroupMemberBLL().GetList(queryBuilder);
                    IM_TalkGroupHintBLL talkGroupHintBLL = new IM_TalkGroupHintBLL();
                    foreach (IM_GroupMemberInfo tmpModel in groupMemberList)
                    {
                        IM_TalkGroupHintInfo talkGroupHintModel = new IM_TalkGroupHintInfo();
                        talkGroupHintModel.ID = Guid.NewGuid();
                        talkGroupHintModel.TalkGroupID = talkGroupModel.ID;
                        talkGroupHintModel.GroupID = talkGroupModel.GroupID;
                        talkGroupHintModel.UserID = tmpModel.UserID;
                        talkGroupHintModel.State = 0;
                        talkGroupHintBLL.Add(talkGroupHintModel);
                    }
                    return DateTime.Now.ToString();
            }
            return "";
        }

        /// <summary>
        /// 发送聊天内容
        /// </summary>
        /// <param name="SendUserID">群聊中是GroupID</param>
        /// <param name="ReceiveUserID"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [WebMethod]
        public string sendUserTalkRec(string SendUserID, string ReceiveUserID, string TalkType)
        {
            string json = "";
            string jsonItem = "";

            switch (TalkType)
            {
                case "1"://单聊
                    IM_TalkBLL talkBLL = new IM_TalkBLL();
                    List<IM_TalkInfo> talkList = talkBLL.GetList(new Guid(SendUserID), new Guid(ReceiveUserID), 1);
                    foreach (IM_TalkInfo talkModel in talkList)
                    {
                        talkBLL.UpdateForState(talkModel.ID, 2);
                        jsonItem += ",{";
                        jsonItem += "ID:'" + talkModel.ID + "'";
                        jsonItem += ",SendUserName:'" + talkModel.SendUserName + "'";
                        jsonItem += ",SendUserID:'" + talkModel.SendUserID + "'";
                        jsonItem += ",Note:'" + talkModel.Note + "'";
                        jsonItem += ",Type:'" + talkModel.Type + "'";
                        jsonItem += ",CreateDate:'" + talkModel.CreateDate + "'";
                        jsonItem += "}";
                    }
                    json += "TalkList:[" + (jsonItem.Length == 0 ? "" : jsonItem.Substring(1)) + "]";
                    break;
                case "2"://群聊
                    IM_TalkGroupBLL talkGroupBLL = new IM_TalkGroupBLL();
                    IM_TalkGroupHintBLL talkGroupHintBLL = new IM_TalkGroupHintBLL();
                    List<IM_TalkGroupInfo> talkGroupList = talkGroupBLL.GetList(new Guid(SendUserID), new Guid(ReceiveUserID));
                    foreach (IM_TalkGroupInfo talkGroupModel in talkGroupList)
                    {
                        talkGroupHintBLL.UpdateForState(talkGroupModel.ID, new Guid(ReceiveUserID), 2);
                        jsonItem += ",{";
                        jsonItem += "ID:'" + talkGroupModel.ID + "'";
                        jsonItem += ",SendUserName:'" + talkGroupModel.UserName + "'";
                        jsonItem += ",SendUserID:'" + talkGroupModel.SendUserID + "'";
                        jsonItem += ",Note:'" + talkGroupModel.Note + "'";
                        jsonItem += ",Type:'" + talkGroupModel.Type + "'";
                        jsonItem += ",CreateDate:'" + talkGroupModel.CreateDate + "'";
                        jsonItem += "}";
                    }
                    json += "TalkList:[" + (jsonItem.Length == 0 ? "" : jsonItem.Substring(1)) + "]";
                    break;
            }


            json = "[{" + json + "}]";

            return json;
        }

        /// <summary>
        /// 修改聊天记录状态
        /// </summary>
        /// <param name="SendUserID"></param>
        /// <param name="ReceiveUserID"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [WebMethod]
        public void updateUserTalkState(string TalkID)
        {
            new IM_TalkBLL().UpdateForState(new Guid(TalkID), 2);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteUser(string userID, string teamID)
        {
            return new IM_TeamMemberBLL().Delete(new Guid(userID), new Guid(teamID)) ? "1" : "0";
        }
    }
}
