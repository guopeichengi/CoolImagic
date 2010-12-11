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
    public class AlbumComment_Bus:Comment_Bus
    {
        private AlbumCommentDB mAlbumCommentDB;

        public AlbumComment_Bus()
        {
            mAlbumCommentDB = new AlbumCommentDB();
        }

        public void AddAlbumComment(long albumId, string commentText, string fromUser)
        {
             mAlbumCommentDB.InsertAlbumCommand(albumId, commentText, fromUser);
        }

        public DataTable ViewAlbumCommentByAlbumId(long albumId)
        {
            return mAlbumCommentDB.ViewAlbumCommentListByAlbumId(albumId);
        }

        public void DeleteAllAlbumCommentByAlbumId(long albumId)
        {
            mAlbumCommentDB.DeleteAllAlbumCommentByAlbumId(albumId);
        }

        public void DeleteAlbumCommentByCommentId(long commentId)
        {
            mAlbumCommentDB.DeleteAlbumCommentByCommentId(commentId);
        }
    }
}
