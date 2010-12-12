/*
 * 文档名称：ImageDB
 * 文档说明：图片数据库类
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
 *           2010.11.10 完成
 *           
 * 修改建议：
*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;


namespace CoolImage_Data.Comment
{
    public class AlbumCommentDB:CommentDB
    {
        public void InsertAlbumCommand(long albumId, string commentText, string fromUser)
            //添加用户评论进数据库
        {
            try
            {
                Conn.Open();
                string sql = "insert into albumComment (albumId, commentText, fromUser) values(@albumId, @commentText, @fromUser)";
                //添加用户评论
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@albumId",albumId),
                    new SqlParameter ("@commentText",commentText),
                    new SqlParameter ("@fromUser",fromUser)
                };
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public DataTable ViewAlbumCommentListByAlbumId(long albumId)
        {
            try
            {
                this.Conn.Open();
                string sql = "select * from albumComment where albumId = @albumId";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@albumId",albumId)
                };
                DataTable dt = GetDataTable(sql, parm);
                Conn.Close();
                return dt;
            }
            catch(Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public void DeleteAllAlbumCommentByAlbumId(long albumId)
        //根据用户id删除该用户所有评论
        {
            try
            {
                Conn.Open();
                string sql = "delete albumComment where albumId = @albumId";
                //删除用户评论
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@albumId",albumId),
                };
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public void DeleteAlbumCommentByCommentId(long commentId)
        //根据评论id删除用户评论
        {
            try
            {
                Conn.Open();
                string sql = "delete albumComment where commentId = @commentId";
                //删除用户评论
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@commentId",commentId),
                };
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }


    }
    
}
