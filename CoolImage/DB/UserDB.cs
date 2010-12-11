/*
 * 文档名称：UserDB
 * 文档说明：用户数据库，封装对users表的方法
 * 最后修改日期：2010.11.14
 * 修改历史：2010.11.09 创建
 *           2010.11.14 完成SelectUserByName， InsertUser
 *           2010.11.14 增加私有辅助方法ConvertUser_DataToParams
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
    public class UserDB:BaseDB
    {
        public DataTable SelectedUserByName(string userLoginName)
            //通过loginName得到数据库中users表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Users WHERE [userLoginName] = @userLoginName";
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@userLoginName",userLoginName)
                };
                DataTable dt = GetDataTable(sql,parm);
                Conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }
         
        public DataTable SelectedUserByUserId(long userId)
        //通过loginName得到数据库中users表的信息
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Users WHERE [userId] = @userId";
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



        public DataTable SelectedAllUsers()
            //得到数据库中users表所有的列
        {
            try
            {
                this.Conn.Open();
                string sql = "SELECT * FROM Users";
                DataTable dt = GetDataTable(sql, null);
                Conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public void DeleteUserByUserId(long userId)
        {
            try
            {
                Conn.Open();
                string sql = "delete Users where userId = @userId";
                //添加用户信息进用户列表
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter ("@userId",userId)
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

        public void InsertUser(ref User_Data userData)
            //根据信息插入新的users列
        {
            try
            {
                Conn.Open();
                string sql = "insert into Users (userLoginName,userName,userPassword,sex,birth,MSN,email,logoUrl,question1,answer1,question2,answer2,question3,answer3,descriptions)"
                        +" values (@userLoginName,@userName,@userPassword,@sex,@birth,@MSN,@email,@logoUrl,@question1,@answer1,@question2,@answer2,@question3,@answer3,@descriptions)";
                //添加用户信息进用户列表
                SqlParameter[] parm = this.ConvertUser_DataToParams(ref userData);
                ExecuteNonQuery(sql, parm);
                Conn.Close();
            }
            catch (Exception e)
            {
                Conn.Close();
                throw e;
            }
        }

        public void UpdateUser (ref User_Data userData)
        {
            try
            {
                Conn.Open();
                string sql = "update Users set userName = @userName,birth = @birth,MSN = @MSN,email = @email,descriptions = @descriptions"
                       +" where userId = @userId";
                //添加用户信息进用户列表
                SqlParameter[] parm = this.ConvertUser_DataToParams(ref userData);
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
        private SqlParameter[] ConvertUser_DataToParams(ref User_Data userData)
            //将userData结构中的数据转换到sqlparameter中
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@userId",userData.userId),
                new SqlParameter ("@userLoginName",userData.userLoginName),
                new SqlParameter ("@userName",userData.userName),
                new SqlParameter ("@userPassword",userData.userPassword),
                new SqlParameter ("@sex",userData.sex),
                new SqlParameter ("@birth",userData.birth),
                new SqlParameter ("@MSN",userData.MSN),
                new SqlParameter ("@email",userData.email),
                new SqlParameter ("@logoUrl",userData.logoUrl),
                new SqlParameter ("@question1",userData.question1),
                new SqlParameter ("@answer1",userData.answer1),
                new SqlParameter ("@question2",userData.question2),
                new SqlParameter ("@answer2",userData.answer2),
                new SqlParameter ("@question3",userData.question3),
                new SqlParameter ("@answer3",userData.answer3),
                new SqlParameter ("@descriptions",userData.descriptions)
            };
            return parm;
        }

    }
}
