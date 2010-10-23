using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;

public partial class LoginPage : System.Web.UI.Page 
{
    string checkCode;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Click(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(Server.MapPath("Source/Login/checkCode.txt"));
        checkCode = sr.ReadLine();
        SqlConnection newConnect = new SqlConnection();
        newConnect.ConnectionString =
            "Data Source=PC-20100930WOED;" +
            "Initial Catalog=Register;" +
            "User ID=sa;" +
            "Password=sa;";
        newConnect.Open();
        string search = "SELECT * FROM T_Register WHERE Username='" + UserID.Text.ToString() + "' AND Password='" + UserPwd.Text.ToString() + "'";
        SqlDataAdapter da = new SqlDataAdapter(search, newConnect);
        DataSet ds = new DataSet();
        if (!Check.Text.ToString().Equals(checkCode))
        {
            Tips.Text = "验证码错误";
            return;
        }
        if (da.Fill(ds) <= 0)
        {
            Tips.Text = "用户名密码错误";
            return;
        }
        Tips.Text = "登陆成功";
    }
}
