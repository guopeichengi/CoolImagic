/*
 * 文档名称：data_structures
 * 文档说明：记录对象信息的结构，用于页面间session的传递。
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
 *           2010.11.22 增加数据结构类ImageList,用与处理相册图片数据集
 *           
 * 修改建议：comment_data由于参数很少也不需要页面传递，不会用到，先留着
 *           数据结构应该单独建立文件。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolImage_Structures
{
   [Serializable]
    public struct User_Data
    {
        public long userId;
        public string userLoginName;
        public string userName;
        public string userPassword;
        public string sex;
        public string birth;
        public string MSN;
        public string email;
        public string logoUrl;
        public string question1;
        public string answer1;
        public string question2;
        public string answer2;
        public string question3;
        public string answer3;
        public string descriptions;

    }

   [Serializable]
    public struct Album_Data
    {
        public long albumId;
        public string albumName;
        public string logoUrl;
        public string descriptions;
        public long userId;
        public string permission;
    }

   [Serializable]
    public struct Image_Data
    {
        public long imageId;
        public string imageName;
        public string imageUrl;
        public string descriptions;
        public string createDate;
        public long albumId;
        public string imageType;
    }

   [Serializable]
    public struct UserComment_Data
    {
        public long commentId;
        public string fromUser;
        public string commentText;
        public long userId;
    }

   [Serializable]
    public struct AlbumComment_Data
    {
        public long commentId;
        public string fromUser;
        public string commentText;
        public long albumId;
    }

   [Serializable]
    public struct ImageComment_Data
    {
        public long commentId;
        public string fromUser;
        public string commentText;
        public long imageId;
    }

}
