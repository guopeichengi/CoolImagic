/*
 * 文档名称：ImageDB
 * 文档说明：图片数据库类
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
 *           2010.11.10 完成了一系列添加和浏览数据的方法
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
    public class ImageDB:BaseDB
    {
        public void InsertImage(ref Image_Data imageData)
        //根据信息插入新的images列
        {
            try
            {
                Conn.Open();
                string sql = "insert into Images (imageName,albumId,descriptions,imageUrl,createDate,imageType)"
                       +" values(@imageName,@albumId,@descriptions,@imageUrl,@createDate,@imageType)";
                //添加图片信息进图片列表
                SqlParameter[] parm = this.ConvertImage_DataToParams(ref imageData);
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public DataTable SelectedImageListByAlbumId(long albumId)
        //通过albumId得到数据库中images表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Images WHERE [albumId] = @albumId";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@albumId",albumId)
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

        public DataTable SelectedImageByImageNameAlbumId(long albumId, string imageName)
        //通过albumId得到数据库中images表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Images WHERE [albumId] = @albumId And [imageName] = @imageName";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@albumId",albumId),
                    new SqlParameter ("@imageName",imageName)
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

        public DataTable SelectedImageByImageId(long imageId)
        //通过imageId得到数据库中images表的信息
        {
            try
            {
                Conn.Open();
                string sql = "SELECT * FROM Images WHERE [imageId] = @imageId";
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

        public DataTable SelectedImageListByUserId(long userId)
        //得到指定userId的照片数据
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT Images.* FROM Images,Albums WHERE Images.albumId = Albums.albumId And Albums.userId = @userId";
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
                Conn.Close();
                throw e;
            }
        }

        public void UpdateImage(ref Image_Data imageData)
        {
            try
            {
                Conn.Open();
                string sql = "update Images set imageType = @imageType,imageName = @imageName,descriptions = @descriptions where imageId = @imageId";
                //添加用户信息进用户列表
                SqlParameter[] parm = this.ConvertImage_DataToParams(ref imageData);
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public void DeleteImageByImageId(long imageId)
        {
            try
            {
                Conn.Open();
                string sql = "delete Images where imageId = @imageId";
                //添加用户信息进用户列表
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@imageId",imageId)
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

        public void DeleteAllImageByAlbumId(long albumId)
        {
            try
            {
                Conn.Open();
                string sql = "delete Images where albumId = @albumId";
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
        private SqlParameter[] ConvertImage_DataToParams(ref Image_Data imageData)
        //将userData结构中的数据转换到sqlparameter中
        {
            SqlParameter[] parm = new SqlParameter[]                   
            {
                new SqlParameter ("@imageid",imageData.imageId),
                new SqlParameter ("@imageName",imageData.imageName),
                new SqlParameter ("@createDate",imageData.createDate),
                new SqlParameter ("@albumId",imageData.albumId),
                new SqlParameter ("@descriptions",imageData.descriptions),
                new SqlParameter ("@imageUrl",imageData.imageUrl),
                new SqlParameter ("@imageType",imageData.imageType)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
            };
            return parm;
        }

    }
}
