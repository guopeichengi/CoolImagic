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
using CoolImage_Structures;
using CoolImage_Bus;
using System.IO;

namespace CoolImage
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        User_Bus mUser = new User_Bus();
        User_Data mUserData = new User_Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_data"] == null)
                Response.Redirect("default.aspx");


            mUserData = (User_Data)Session["user_data"];

            if (!Page.IsPostBack)
            {
                userNameTB.Text = mUserData.userName;
                EmailTB.Text = mUserData.email;
                MSNTB.Text = mUserData.MSN;
                descriptionTB.Text = mUserData.descriptions;
            }

        }

        protected void ensureUpdateB_Click(object sender, EventArgs e)
        {
            mUserData.userName = userNameTB.Text.ToString();
            mUserData.email = EmailTB.Text.ToString();
            mUserData.MSN = MSNTB.Text.ToString();
            mUserData.descriptions = descriptionTB.Text.ToString();

            mUser.UpdateUser(ref mUserData, userLogoFU);

            Session["user_data"] = mUserData;

            Response.Redirect("Home.aspx?userId=" + Convert.ToString(mUserData.userId), true);
        }

        protected void ReuturnHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?userId=" + Convert.ToString(mUserData.userId), true);
        }
    }
}
