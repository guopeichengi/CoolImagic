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
    public class ImageComment_Bus:Comment_Bus 
    {
        private ImageCommentDB mImageCommentDB;

        public ImageComment_Bus()
        {
            mImageCommentDB = new ImageCommentDB();
        }

        public void AddImageComment(long imageId, string commentText, string fromUser)
        {
            mImageCommentDB.InsertImageCommand(imageId, commentText, fromUser);
        }

        public DataTable ViewImageCommentByImageId(long imageId)
        {
            return mImageCommentDB.ViewImageCommentListByImageId(imageId);
        }

        public void DeleteAllImageCommentByImageId(long imageId)
        {
            mImageCommentDB.DeleteAllImageCommentByImageId(imageId);
        }

        public void DeleteImageCommentByCommentId(long commentId)
        {
            mImageCommentDB.DeleteImageCommentByCommentId(commentId);
        }
    }
}
