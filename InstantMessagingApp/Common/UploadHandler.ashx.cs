using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using IM.BLL;
using IM.Model;
using XSAT.Lib2014.System.Data;

namespace InstantMessagingApp
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Services.WebServiceBinding(ConformsTo = System.Web.Services.WsiProfiles.BasicProfile1_1)]
    public class UploadHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        string FileID = "";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["Filedata"];
            string uploadPath = context.Server.MapPath("~/UpLoadFiles/Files/");
            string ReceiveID = context.Request["ReceiveID"].Replace("'", "");
            string UserID = context.Request["UserID"].Replace("'", "");
            string Type = context.Request["Type"].Replace("'", "");
            string FileName = "";
            string FileType = "";

            if (file != null)
            {
                FileID = Guid.NewGuid().ToString();
                FileType = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower();
                FileName = file.FileName.Substring(0, file.FileName.LastIndexOf('.'));
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                uploadPath += FileID + "." + FileType;
                file.SaveAs(uploadPath);
                FileName += "." + FileType;

                IM_FileInfo fileModel = new IM_FileInfo();
                fileModel.ID = Guid.NewGuid();
                fileModel.FileName = FileName;
                fileModel.FilePath = "/UpLoadFiles/Files/" + FileID + "." + FileType;
                fileModel.UserID = new Guid(UserID);
                fileModel.ReceiveID = new Guid(ReceiveID);
                fileModel.Type = 1;
                fileModel.CreateDate = DateTime.Now;
                new IM_FileBLL().Add(fileModel);

                string Note = "<a href=\"" + fileModel.FilePath + "\" target=\"_blank\">" + fileModel.FileName + "</a>";
                switch (Type)
                {
                    case "1":
                        IM_TalkInfo talkModel = new IM_TalkInfo();
                        talkModel.SendUserID = fileModel.UserID;
                        talkModel.ReceiveUserID = fileModel.ReceiveID;
                        talkModel.Note = Note;
                        talkModel.Type = 1;
                        talkModel.State = 0;
                        new IM_TalkBLL().Add(talkModel);
                        break;
                    case "2":
                        IM_TalkGroupInfo talkGroupModel = new IM_TalkGroupInfo();
                        talkGroupModel.ID = Guid.NewGuid();
                        talkGroupModel.SendUserID = fileModel.UserID;
                        talkGroupModel.GroupID = fileModel.ReceiveID;
                        talkGroupModel.Note = Note;
                        talkGroupModel.Type = 1;
                        new IM_TalkGroupBLL().Add(talkGroupModel);

                        QueryBuilder queryBuilder = new QueryBuilder();
                        queryBuilder.AddFilter(IM_GroupMemberInfo.GroupID_Field, "=", fileModel.ReceiveID.ToString());
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
                        break;
                }

            }
            context.Response.Write(ReceiveID + "|" + FileName + "|" + "/UpLoadFiles/Files/" + FileID + "." + FileType + "|" + DateTime.Now);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}