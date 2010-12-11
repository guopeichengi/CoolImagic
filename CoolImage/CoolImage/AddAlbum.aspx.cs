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
    public partial class AddAlbum : System.Web.UI.Page
    {
        Album_Bus mAlbum = new Album_Bus();
        Album_Data mAlbumData = new Album_Data();
        User_Data mUserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_data"] == null)
                Response.Redirect("default.aspx");

            mUserData = (User_Data)Session["user_data"];
        }

        protected void ensureB_Click(object sender, EventArgs e)
        {

            if (!mAlbum.CheckAlbumNameOnly(albumNameTB.Text.ToString(), mUserData.userId))
            {
                Response.Write("<script>alert('相册名重复！');</script>");
                return;
            }

            mAlbumData.userId = mUserData.userId;
            mAlbumData.albumName = albumNameTB.Text.ToString();
            mAlbumData.descriptions = descriptionTB.Text.ToString();
            mAlbumData.permission = permissionTB.Text.ToString();

            mAlbum.AddAlbum(ref mAlbumData, mUserData.userLoginName, albumLogoFU);

            Response.Redirect("Home.aspx?userId="+Convert.ToString(mUserData.userId),true);

        }

        protected void ReuturnHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?userId=" + Convert.ToString(mUserData.userId), true);
        }

    }
}