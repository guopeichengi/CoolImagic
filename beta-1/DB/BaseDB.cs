/*
 * 文档名称：BaseDB
 * 文档说明：各数据库的基类
 * 最后修改日期：2010.11.09
 * 修改历史：2010.11.09 创建
 *           
 *           
 * 修改建议：链接字符应该存在webconf里
 *           不熟悉sqlReader的用法
*/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace CoolImage_Data
{
    public class BaseDB
    {
        //链接字符
        private static readonly string ConnectionString = "Data Source=WY-20100508QDIU;Initial Catalog=CoolImage;User ID=sa;password=saa";
        private SqlConnection conn = new SqlConnection(ConnectionString);

        protected SqlConnection Conn
        {
            get
            {
                return conn;
            }
        }

        protected SqlCommand GetCommand(string sqlStr, params SqlParameter[] cmdparms)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlStr;
            cmd.CommandType = CommandType.Text;
            if (cmdparms != null)
            {
                foreach (SqlParameter p in cmdparms)
                {
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        protected SqlDataReader GetReader(string cmdtext, params SqlParameter[] cmdparms)
        {
            SqlCommand command = this.GetCommand(cmdtext,cmdparms);
            return command.ExecuteReader();
        }

        protected void ExecuteNonQuery(string cmdtext, params SqlParameter[] cmdparms)
        {
            SqlCommand command = this.GetCommand(cmdtext,cmdparms);
            command.ExecuteNonQuery();
        }

        protected DataTable GetDataTable(string cmdtext, params SqlParameter[] cmdparms)
        {
            SqlDataAdapter sqlAd = new SqlDataAdapter(this.GetCommand(cmdtext,cmdparms));
            DataSet ds = new DataSet();
            sqlAd.Fill(ds);
            return ds.Tables[0];
        }

       
    }
}
