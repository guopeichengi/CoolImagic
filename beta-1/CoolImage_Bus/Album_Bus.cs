/*
 * 文档名称：Album_Bus
 * 文档说明：相册信息业务层，管理相册数据库
 *           类的使用以及相关相册文件操作。
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建，并完成一些函数。
 *           2010.11.11 修改AddAlbum函数并且增加一个abUrl属性指定该相册文件夹所在位置。
 *           2010.11.20 完成更新操作
 *           2010.11.20 完成删除，删除操作效率很低，主要是因为使用迭代删除image
 *           
 * 修改建议：文件路径用法比较别扭
 *           删除操作应该使用image_Bus的方法？
 *           由于首页面fileupload和server的依赖，部分文件操作没有封装在类里，是否有更好的做法？
*/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using CoolImage_Structures;
using CoolImage_Data;
using CoolImage_Bus.Comment;
using System.IO;
using System.Web.UI.WebControls;

namespace CoolImage_Bus
{
    public class Album_Bus:Base_Bus
    {
        AlbumDB mAlbumDB;   
        Image_Bus mImage;
        AlbumComment_Bus mComment;

        public Album_Bus()
        {
            mAlbumDB = new AlbumDB();
            mImage = new Image_Bus();
            mComment = new AlbumComment_Bus();
        }

        public bool CheckAlbumNameOnly(string albumName, long userId)
        //该用户是否拥有该相册名的相册
        {
            DataTable dt = mAlbumDB.SelectedAlbumByUserIdAlbumName(userId, albumName);
            if (dt.Rows.Count > 0)
                return false;
            return true;

        }

        public void AddAlbum(ref Album_Data albumData, string absoluteUrl)
        {
            //加入新的相册，包括数据库，创建相册文件夹和设置logo的路径
            CreateAlbumFile(absoluteUrl);
            mAlbumDB.InsertAlbum(ref albumData);
        }

        public void AddAlbum(ref Album_Data albumData, string userLoginName,FileUpload albumLogoFU)
        {
            //创建相册并且创建相册目录
            CreateAlbumFile(MAP_PATH+"\\"+BASE_PATH+"\\"+USER_FILE_PREFIX+userLoginName+"\\"+ALBUM_FILE_PREFIX+albumData.albumName);
            albumData.logoUrl = BASE_PATH + "\\" + USER_FILE_PREFIX + userLoginName + "\\" + ALBUM_FILE_PREFIX + albumData.albumName
                                + "\\" + ALBUM_LOGO_PREFIX + albumData.albumName;

            string exname;
            if (albumLogoFU.FileName.Length > 0)
            {
                exname = albumLogoFU.FileName.Split('.')[1];
                if (exname.ToLower() == "jpg" || exname.ToLower() == "gif" || exname.ToLower() == "png")
                {
                    albumData.logoUrl += "." + exname;
                    albumLogoFU.SaveAs(MAP_PATH+"\\"+albumData.logoUrl);
                }
            }
            
            mAlbumDB.InsertAlbum(ref albumData);
        }

        public DataTable ViewAlbumListByUserId(long userId)
            //通过用户id得到用户的相册列表
        {
            return mAlbumDB.SelectedAlbumListByUserId(userId);
        }

        public void GetAlbumByAlbumId(long albumId, ref Album_Data album_data)
            //通过相册的id存放相册信息到album_data
        {
            DataTable dt = mAlbumDB.SelectedAlbumByAlbumId(albumId);
            ConvertDataTableToAlbum_Data(dt, ref album_data);
        }

        public void UpdateAlbum(ref Album_Data album_data, FileUpload albumLogoFU)
            //更新相册
        {
            string exname;
            if (albumLogoFU.FileName.Length > 0)
            {
                exname = albumLogoFU.FileName.Split('.')[1];
                if (exname.ToLower() == "jpg" || exname.ToLower() == "gif" || exname.ToLower() == "png")
                {
                    albumLogoFU.SaveAs(MAP_PATH + "\\" + album_data.logoUrl);
                }
            }
            
            mAlbumDB.UpdateAlbum(ref album_data);
        }

        public void DeleteAlbumByAlbumId(long albumId, string abAlbumPath)
            //删除操作
        {
            //文件删除
            if (abAlbumPath != null)
            {
                try
                {
                    Directory.Delete(abAlbumPath, true);

                    //迭代删除数据库数据
                    ImageComment_Bus imageComment = new ImageComment_Bus();
                    Image_Bus image = new Image_Bus();
                    DataTable dt = image.ViewImageListByAlbumId(albumId);
                    long count = dt.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        imageComment.DeleteAllImageCommentByImageId(Convert.ToInt64(dt.Rows[i]["imageId"]));
                    }
                    ImageDB imageDB = new ImageDB();
                    imageDB.DeleteAllImageByAlbumId(albumId);
                    mComment.DeleteAllAlbumCommentByAlbumId(albumId);
                    mAlbumDB.DeleteAlbumByAlbumId(albumId);
                }
                catch (Exception e)
                {
                    //
                }
            }

        }



        public void DeleteAlbumByAlbumId(long albumId, string userLoginName, string albumName)
        //删除操作
        {
            try
            {
                string albumPath = MAP_PATH + "\\" + BASE_PATH + "\\" + USER_FILE_PREFIX + userLoginName
                              + "\\" + ALBUM_FILE_PREFIX + albumName;
                Directory.Delete(albumPath, true);

                ImageComment_Bus imageComment = new ImageComment_Bus();
                Image_Bus image = new Image_Bus();
                DataTable dt = image.ViewImageListByAlbumId(albumId);
                long count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    imageComment.DeleteAllImageCommentByImageId(Convert.ToInt64(dt.Rows[i]["imageId"]));
                }
                ImageDB imageDB = new ImageDB();
                imageDB.DeleteAllImageByAlbumId(albumId);
                mComment.DeleteAllAlbumCommentByAlbumId(albumId);
                mAlbumDB.DeleteAlbumByAlbumId(albumId);
            }
            catch (Exception e)
            {
                //
            }

            
        }

        private void CreateAlbumFile(string absoluteUrl)
        //添加用户文件夹，里面存放的是用户的Logo，相册等信息。
        //参数absoluteUrl：用户文件夹的绝对路径，用用户登录名作为文件夹名字
        {
            if (!Directory.Exists(absoluteUrl))
                Directory.CreateDirectory(absoluteUrl);
        }

        private void ConvertDataTableToAlbum_Data(DataTable dt, ref Album_Data album_data)
            //转换dataTabel的首行数据至User_Data结构
        {
            if (dt.Rows.Count < 1)
                return;

            album_data.albumId = Convert.ToInt64(dt.Rows[0]["albumId"]);
            album_data.albumName = dt.Rows[0]["albumName"].ToString();
            album_data.descriptions = dt.Rows[0]["descriptions"].ToString();
            album_data.logoUrl = dt.Rows[0]["logoUrl"].ToString();
            album_data.userId = Convert.ToInt64(dt.Rows[0]["userId"]);
            album_data.permission = dt.Rows[0]["permission"].ToString();
        }
    }
}
