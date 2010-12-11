using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using CoolImage_Structures;
using CoolImage_Data.Comment;
using CoolImage_Bus.Comment;
using System.IO;


namespace CoolImage_Bus.Comment
{
    public class UserComment_Bus:Comment_Bus
    {
        private UserCommentDB mUserCommentDB;

        public UserComment_Bus()
        {
            mUserCommentDB = new UserCommentDB();
        }

        public void AddUserComment(long userId, string commentText, string fromUserName)
        {
            mUserCommentDB.InsertUserCommand(userId, commentText, fromUserName);
        }

        public DataTable ViewUserCommentByUserId(long userId)
        {
            return mUserCommentDB.ViewUserCommentListByUserId(userId);
        }

        public void DeleteAllUserCommentByUserId(long userId)
        {
            mUserCommentDB.DeleteAllUserCommentByUserId(userId);
        }

        public void DeleteUserCommentByCommentId(long commentId)
        {
            mUserCommentDB.DeleteUserCommentByCommentId(commentId);
        }


    }
}
