/*
 * 文档名称：User_Bus
 * 文档说明：用户信息业务层，管理用户数据库
 *           类的使用以及相关用户文件操作。
 * 最后修改日期：2010.11.13
 * 修改历史：2010.11.09 创建
 *           2010.11.10 完成AddUser方法及CheckUserByName方法
 *           2010.11.11 完成Login方法
 *           2010.11.14 CreateUserFile的参数不得已被改变，加入用户文件夹的绝对路径
 *           2010.11.14 修改RegisterUser，增加一行处理userData.logoUrl
 *           2010.11.20 在基类中增加统一的文件命名字段
 *                     
 * 
 * 修改建议：方法传递参数缺少必要注释说明
 *           文件夹虚拟路径无法得到！！
 *           用户logo不设扩展名，不知道会不会有什么问题。要设的话但存在对外部页面类fileupload对象的依赖。
 *           由于首页面fileupload和server的依赖，部分文件操作没有封装在类里，是否有更好的做法？
 *           不如设一个FileHelper类，统一管理所有用户文件的绝对路径前缀，图片文件名前缀和logo前缀
 *           
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
    public class User_Bus:Base_Bus
        //用户业务类，管理用户操作功能（注册，登录等）
        //的逻辑实现，以及文件操作和数据库操作的关联。
    {
        private UserDB mUserDB;
        private Album_Bus mAlbum_Bus;
        private UserComment_Bus mComment_Bus;

        public User_Bus()
            //构造函数
        {
            mUserDB = new UserDB();
            mAlbum_Bus = new Album_Bus();
            mComment_Bus = new UserComment_Bus();
        }
   
        public void RegisterUser(ref User_Data userData, FileUpload fileUpload)
            //添加用户，参数absoluteUrl：用户文件夹的绝对路径，用用户登录名作为文件夹名字
        {
            string filePath = MAP_PATH + "\\" + BASE_PATH + "\\" + USER_FILE_PREFIX + userData.userLoginName;
            userData.logoUrl = BASE_PATH + "\\" + USER_FILE_PREFIX + userData.userLoginName + "\\" + USER_LOGO_PREFIX + userData.userLoginName;

            if (fileUpload.FileName.Length > 0)
            {
                string exname = fileUpload.FileName.Split('.')[1];
                if (exname.ToLower() == "jpg" || exname.ToLower() == "gif" || exname.ToLower() == "png")
                {
                    userData.logoUrl += "." + exname;
                    CreateUserFile(filePath);
                    fileUpload.SaveAs(MAP_PATH + "\\" + userData.logoUrl);
                    mUserDB.InsertUser(ref userData);
                }
            }         
        }

        public bool CheckUserLoginNameOnly(string userLoginName)
            //用户名是否存在
        {
            DataTable dt = mUserDB.SelectedUserByName(userLoginName);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        public void GetUserDataByUserId(long id, ref User_Data user_data)
        {
            DataTable dt = mUserDB.SelectedUserByUserId(id);
            ConvertDataTableToUser_Data(dt, ref user_data);
        }

        public bool Login(string LoginName, string password, ref User_Data user_data) 
            //用户登录，返回用户登录名和密码是否匹配
        {
            DataTable dt = mUserDB.SelectedUserByName(LoginName);
            if (dt.Rows.Count == 0)
                return false;
            if (!(dt.Rows[0]["UserPassword"].ToString() == password))
                return false;
            this.ConvertDataTableToUser_Data(dt, ref user_data);
            return true;
        }

        public void UpdateUser(ref User_Data userData)
            //用户更新
        {
            mUserDB.UpdateUser(ref userData);
        }
        
        public void UpdateUser(ref User_Data userData, FileUpload userLogoFU)
        //用户更新
        {
            string exname;
            if (userLogoFU.FileName.Length > 0)
            {
                exname = userLogoFU.FileName.Split('.')[1];
                if (exname.ToLower() == "jpg" || exname.ToLower() == "gif" || exname.ToLower() == "png")
                {
                    userLogoFU.SaveAs(MAP_PATH + "\\" + userData.logoUrl);
                }
            }
            mUserDB.UpdateUser(ref userData);
        }


        
        public void DeleteUser(long userId,string abUserPath)
        {
            try
            {
                if (abUserPath != null)
                {
                    Directory.Delete(abUserPath, true);
                }

                DataTable dt = mAlbum_Bus.ViewAlbumListByUserId(userId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mAlbum_Bus.DeleteAlbumByAlbumId(Convert.ToInt64(dt.Rows[i]["albumId"]), null);
                }
                mComment_Bus.DeleteAllUserCommentByUserId(userId);
                mUserDB.DeleteUserByUserId(userId);
            }
            catch (Exception e)
            {
                //
            }
        }
        


        public void DeleteUser(string userLoginName,long userId)
        {
            try
            {
                string userFilePath = MAP_PATH + "\\" + BASE_PATH + "\\" + USER_FILE_PREFIX + userLoginName;
                Directory.Delete(userFilePath, true);
                DataTable dt = mAlbum_Bus.ViewAlbumListByUserId(userId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mAlbum_Bus.DeleteAlbumByAlbumId(Convert.ToInt64(dt.Rows[i]["albumId"]), null);
                }
                mComment_Bus.DeleteAllUserCommentByUserId(userId);
                mUserDB.DeleteUserByUserId(userId);
            }
            catch (Exception e)
            {
                //
            }
  
           
        }

        //私有辅助方法
        private void CreateUserFile(string absoluteUrl)
           //添加用户文件夹，里面存放的是用户的Logo，相册等信息。
           //参数absoluteUrl：用户文件夹的绝对路径，用用户登录名作为文件夹名字
        {
            if (!Directory.Exists(absoluteUrl))
                Directory.CreateDirectory(absoluteUrl);
        }

        private void ConvertDataTableToUser_Data(DataTable dt, ref User_Data user_data)
            //转换dataTabel的首行数据至User_Data结构
        {
            if (dt.Rows.Count < 1)
                return;

            user_data.userId = Convert.ToInt64(dt.Rows[0]["userId"]);
            user_data.userName = dt.Rows[0]["userName"].ToString();
            user_data.userPassword = dt.Rows[0]["userPassword"].ToString();
            user_data.userLoginName = dt.Rows[0]["userLoginName"].ToString();
            user_data.question1 = dt.Rows[0]["question1"].ToString();
            user_data.answer1 = dt.Rows[0]["answer1"].ToString();
            user_data.question2 = dt.Rows[0]["question2"].ToString();
            user_data.answer2 = dt.Rows[0]["answer2"].ToString();
            user_data.question3 = dt.Rows[0]["question3"].ToString();
            user_data.answer3 = dt.Rows[0]["answer3"].ToString();
            user_data.birth = dt.Rows[0]["birth"].ToString();
            user_data.email = dt.Rows[0]["email"].ToString();
            user_data.MSN = dt.Rows[0]["MSN"].ToString();
            user_data.descriptions = dt.Rows[0]["descriptions"].ToString();
            user_data.logoUrl = dt.Rows[0]["logoUrl"].ToString();
            user_data.sex = dt.Rows[0]["sex"].ToString();
        }
    }
}
