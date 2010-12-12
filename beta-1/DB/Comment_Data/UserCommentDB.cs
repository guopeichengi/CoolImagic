/*
 * 文档名称：UserCommentDB
 * 文档说明：用户评论数据类
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
 *           2010.11.10 完成
 *           
 * 修改建议：根据clean Code的要求重构各方法
*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace CoolImage_Data.Comment
{
    public class UserCommentDB:CommentDB
    {
        public void InsertUserCommand(long userId, string commentText, string fromUser)
            //添加用户评论进数据库
        {
            try
            {
                Conn.Open();
                string sql = "insert into userComment (userId, commentText, fromUser) values(@userId, @commentText, @fromUser)";
                //添加用户评论

                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@userId",userId),
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

        public DataTable ViewUserCommentListByUserId(long userId)
            //根据用户id浏览用户评论
        {
            try
            {
                this.Conn.Open();
                string sql = "select * from userComment where userId = @userId";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@userId",userId)
                };
                DataTable dt = GetDataTable(sql, parm);
                Conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Conn.Close();
            }
        }

        public void DeleteAllUserCommentByUserId(long userId)
        //根据用户id删除该用户所有评论
        {
            try
            {
                Conn.Open();
                string sql = "delete userComment where userId = @userId";
                //删除用户评论
                SqlParameter[] parm = new SqlParameter[] 
                {
                    new SqlParameter ("@userId",userId),
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

        public void DeleteUserCommentByCommentId(long commentId)
        //根据评论id删除用户评论
        {
            try
            {
                Conn.Open();
                string sql = "delete userComment where commentId = @commentId";
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
