/*
 * 文档名称：ImageBus
 * 文档说明：图片业务类，封装一系列图片的操作（增删查改搜)，配合文件与数据库类操作
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
 *          
 *           
 * 修改建议：由于首页面fileupload和server的依赖，部分文件操作没有封装在类里，是否有更好的做法？
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
    public class Image_Bus:Base_Bus
    {
        private ImageDB mImageDB;
        private ImageComment_Bus mComment;

        public Image_Bus()
        {
            mImageDB = new ImageDB();
            mComment = new ImageComment_Bus();   
        }

        public bool CheckImageNameUnique(string imageName, long albumId)
        //该相册是否拥有该图片名的图片
        {
            DataTable dt = mImageDB.SelectedImageByImageNameAlbumId(albumId, imageName);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        public void AddImage(ref Image_Data imageData)
        {
            //加入新的图片，包括数据库，设置服务器图片的路径
            mImageDB.InsertImage(ref imageData);
        }

        public void AddImage(ref Image_Data imageData,string userLoginName, string albumName, FileUpload imageUrlFU)
        {
            //加入新的图片，包括数据库，根据给出的userLoginName和albumName计算路径
            imageData.imageUrl = BASE_PATH + "\\"
                                + USER_FILE_PREFIX + userLoginName + "\\"
                                + ALBUM_FILE_PREFIX + albumName + "\\"
                                + IMAGE_PREFIX + imageData.imageName;

            if (imageUrlFU.FileName.Length > 0)
            {
                string exname = imageUrlFU.FileName.Split('.')[1];
                if (exname.ToLower() == "jpg" || exname.ToLower() == "gif" || exname.ToLower() == "png")
                {
                    imageData.imageUrl += "." + exname;
                    imageUrlFU.SaveAs(MAP_PATH + "\\" + imageData.imageUrl);
                }
            }
            mImageDB.InsertImage(ref imageData);
        }

        public DataTable ViewImageListByAlbumId(long albumId)
        //根据相册id展示相册的图片
        {
            return mImageDB.SelectedImageListByAlbumId(albumId);
        }

        public void GetImageByImageId(long imageId, ref Image_Data image_data)
        //通过图片的id存放图片信息到image_data
        {
            DataTable dt = mImageDB.SelectedImageByImageId(imageId);
            ConvertDataTableToImage_Data(dt, ref image_data);
        }


        public void UpdateImage(ref Image_Data imageData, FileUpload imageUrlFU)
            //更新操作
        {
            string exname;
            if (imageUrlFU.FileName.Length > 0)
            {
                exname = imageUrlFU.FileName.Split('.')[1];
                if (exname.ToLower() == "jpg" || exname.ToLower() == "gif" || exname.ToLower() == "png")
                {
                    imageUrlFU.SaveAs(MAP_PATH + "\\" + imageData.imageUrl);
                }
            }
            mImageDB.UpdateImage(ref imageData);
        }

        
        public void DeleteImageByImageId(long imageId, string abImagePath)
            //根据imageId删除
        {
            try
            {
                File.Delete(abImagePath);
                mComment.DeleteAllImageCommentByImageId(imageId);
                mImageDB.DeleteImageByImageId(imageId);
            }
            catch (Exception e)
            {
                //
            }
        }

        public void DeleteImageByImageIdImageUrl(long imageId, string imageUrl)
            //根据imageId删除
        {
            try
            {
                string imagePath = MAP_PATH + "\\" + imageUrl;
                File.Delete(imagePath);
                mComment.DeleteAllImageCommentByImageId(imageId);
                mImageDB.DeleteImageByImageId(imageId);
            }
            catch (Exception e)
            {
                //
            }
        }


        //辅助方法
        private void ConvertDataTableToImage_Data(DataTable dt, ref Image_Data image_data)
        //转换dataTabel的首行数据至Image_Data结构
        {
            if (dt.Rows.Count < 1)
                return;

            image_data.imageId = Convert.ToInt64(dt.Rows[0]["imageId"]);
            image_data.imageName = dt.Rows[0]["imageName"].ToString();
            image_data.imageUrl = dt.Rows[0]["imageUrl"].ToString();
            image_data.imageType = dt.Rows[0]["imageType"].ToString();
            image_data.createDate = dt.Rows[0]["createDate"].ToString();
            image_data.descriptions = dt.Rows[0]["descriptions"].ToString();
            image_data.albumId = Convert.ToInt64(dt.Rows[0]["albumId"]);
        }
    }
}
