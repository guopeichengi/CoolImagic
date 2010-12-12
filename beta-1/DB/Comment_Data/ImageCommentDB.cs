/*
 * 文档名称：ImageCommentDB
 * 文档说明：图片评论数据库类
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
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
    public class ImageCommentDB:CommentDB
    {
        public void InsertImageCommand(long imageId, string commentText, string fromUser)
        //添加用户评论进数据库
        {
            try
            {
                Conn.Open();
                string sql = "insert into ImageComment (imageId, commentText, fromUser) values(@imageId, @commentText, @fromUser)";
                //添加用户评论
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@imageId",imageId),
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

        public DataTable ViewImageCommentListByImageId(long imageId)
        {
            try
            {
                this.Conn.Open();
                string sql = "select * from imageComment where imageId = @imageId";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@imageId",imageId)
                };
                DataTable dt = GetDataTable(sql, parm);
                Conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public void DeleteAllImageCommentByImageId(long imageId)
        //根据用户id删除该用户所有评论
        {
            try
            {
                Conn.Open();
                string sql = "delete imageComment where imageId = @imageId";
                //删除用户评论
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@imageId",imageId),
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

        public void DeleteImageCommentByCommentId(long commentId)
        //根据评论id删除用户评论
        {
            try
            {
                Conn.Open();
                string sql = "delete imageComment where commentId = @commentId";
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
