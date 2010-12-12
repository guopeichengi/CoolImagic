/*
 * 文档名称：AlbumDB
 * 文档说明：相册数据库类
 * 修改历史：2010.11.09 创建
 *          
 *           
 * 修改建议：
*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using CoolImage_Structures;


namespace CoolImage_Data
{
    public class AlbumDB:BaseDB
    {

        public DataTable SelectedAlbumListByUserId(long userId)
        //通过userId得到数据库中users表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Albums WHERE [userId] = @userId";
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
                this.Conn.Close();
                throw e;
            }
        }


        public DataTable SelectedAlbumByUserIdAlbumName(long userId, string albumName)
        //通过userid和albumName得到数据库中users表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Albums WHERE [userId] = @userId and [albumName] = @albumName";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@userId",userId),
                    new SqlParameter ("@albumName",albumName)
                };
                DataTable dt = GetDataTable(sql, parm);
                Conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                this.Conn.Close();
                throw e;
            }
        }

        public DataTable SelectedAlbumByAlbumId(long albumId)
        //通过albumId得到数据库中users表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Albums WHERE [albumId] = @albumId";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@albumId",albumId),     
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

        public void InsertAlbum(ref Album_Data albumData)
        //根据信息插入新的users列
        {
            try
            {
                Conn.Open();
                string sql = "insert into Albums (albumName,userId,descriptions,logoUrl,permission)"
                        +" values(@albumName,@userId,@descriptions,@logoUrl,@permission)";
                //添加用户信息进用户列表
                SqlParameter[] parm = this.ConvertAlbum_DataToParams(ref albumData);
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {

                Conn.Close();
                throw e;
            }
        }
        public void UpdateAlbum(ref Album_Data albumData)
        {
            try
            {
                Conn.Open();
                string sql = "update Albums set albumName = @albumName,permission = @permission,descriptions = @descriptions"
                        +" where albumId = @albumId";
                //添加用户信息进用户列表
                SqlParameter[] parm = this.ConvertAlbum_DataToParams(ref albumData);
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {

                Conn.Close();
                throw e;
            }
        }

        public void DeleteAlbumByAlbumId(long albumId)
        {
            try
            {
                Conn.Open();
                string sql = "delete Albums where albumId = @albumId";
                //添加用户信息进用户列表
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@albumId",albumId)
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


        //辅助方法
        private SqlParameter[] ConvertAlbum_DataToParams(ref Album_Data albumData)
        //将userData结构中的数据转换到sqlparameter中
        {
            SqlParameter[] parm = new SqlParameter[]                   
            {
                new SqlParameter ("@albumId",albumData.albumId),
                new SqlParameter ("@albumName",albumData.albumName),
                new SqlParameter ("@userId",albumData.userId),
                new SqlParameter ("@descriptions",albumData.descriptions),        
                new SqlParameter ("@logoUrl",albumData.logoUrl),
                new SqlParameter ("@permission",albumData.permission)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
            };
            return parm;
        }

    }
}
