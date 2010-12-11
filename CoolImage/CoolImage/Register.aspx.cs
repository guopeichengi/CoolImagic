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
    public partial class Register : System.Web.UI.Page
    {
        User_Bus mUser = new User_Bus();
        User_Data mUserData = new User_Data();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerSureTB_Click(object sender, EventArgs e)
        {
            if (!mUser.CheckUserLoginNameOnly(userLoginNameTB.Text.ToString()))
            {
                Response.Write("<script>alert('用户登录名已存在！');</script>");
                return;
            }

            mUserData.userName = userNameTB.Text.ToString();
            mUserData.userPassword = passwordTB.Text.ToString();
            mUserData.userLoginName = userLoginNameTB.Text.ToString();

            mUserData.question1 = question1TB.Text.ToString();
            mUserData.answer1 = answer1TB.Text.ToString();
            mUserData.question2 = question2TB.Text.ToString();
            mUserData.answer2 = answer2TB.Text.ToString();
            mUserData.question3 = question3TB.Text.ToString();
            mUserData.answer3 = answer3TB.Text.ToString();

            mUserData.birth = YDDL.Text.ToString() + "." + MDDL.Text.ToString() + "." + DDDL.Text.ToString();
            mUserData.email = EmailTB.Text.ToString();
            mUserData.MSN = MSNTB.Text.ToString();
            mUserData.descriptions = descriptionTB.Text.ToString();
            mUserData.sex = sexDDL.Text.ToString();

            //注册
            mUser.RegisterUser(ref mUserData, userLogoFU);

            Response.Redirect("Default.aspx");

        }

        protected void CancelB_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}
