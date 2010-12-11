using System;
using System.Collections;
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
using CoolImage_Bus;
using CoolImage_Structures;

namespace CoolImage
{
    public partial class _Default : System.Web.UI.Page
    {
        private User_Data mUser_Data;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user_data"] == null)
            {
                UserAreaP.Visible = false;
                TouristP.Visible = true;
            }
            else
            {
                TouristP.Visible = false;
                UserAreaP.Visible = true;
            }
        }

        protected void userLoginNameB_Click(object sender, EventArgs e)
        {
            
            User_Bus mUser = new User_Bus();
            if (!mUser.Login(userLoginNameTB.Text.ToString(), passwordTB.Text.ToString(), ref mUser_Data))
            {
                Response.Write("<script>alert('用户登录名或密码错误');</script>");
                return;
            }
            else
            {
                Session["user_data"] = mUser_Data;
            }

            TouristP.Visible = false;
            UserAreaP.Visible = true;
            UserNameL.Text = mUser_Data.userName;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void MyHomeLB_Click(object sender, EventArgs e)
        {
            mUser_Data = (User_Data)Session["user_data"];
            string url = "Home.aspx?userId=" + Convert.ToString(mUser_Data.userId);
            Response.Redirect(url, true);
        }

        protected void ExitLB_Click(object sender, EventArgs e)
        {
            Session["user_data"] = null;
            mUser_Data = new User_Data();

            TouristP.Visible = true;
            UserAreaP.Visible = false ;

        }
    }
}
