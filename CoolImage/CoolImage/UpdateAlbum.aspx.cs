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
    public partial class UpdateAlbum : System.Web.UI.Page
    {

        User_Data mUserData;
        Album_Bus mAlbum = new Album_Bus();
        Album_Data mAlbumData;
        long albumId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_data"] == null || Request.QueryString["albumId"] == null)
            {
                Response.Redirect("Default.aspx",true);
                return;
            }

            mUserData = (User_Data)Session["user_data"];
            albumId = Convert.ToInt64(Request.QueryString["albumId"]);
            mAlbum.GetAlbumByAlbumId(albumId, ref mAlbumData);

            if (mAlbumData.userId != mUserData.userId)
            {
                Response.Redirect("Default.aspx",true);
            }

            if (!Page.IsPostBack)
            {
                descriptionTB.Text = mAlbumData.descriptions;
                permissionTB.Text = mAlbumData.permission;
            }


        }

        protected void ensureB_Click(object sender, EventArgs e)
        {
            if (Session["user_data"] == null)
            {
                Response.Redirect("Default.aspx",true);
                return;
            }

            mAlbumData.descriptions = descriptionTB.Text.ToString();
            mAlbumData.permission = permissionTB.Text.ToString();

            mAlbum.UpdateAlbum(ref mAlbumData, albumLogoFU);     
       
            Response.Redirect("AlbumHome.aspx?albumId="+Convert.ToString(mAlbumData.albumId),true);
        }

        protected void ReturnAlbumHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlbumHome.aspx?albumId=" + Convert.ToString(mAlbumData.albumId), true);
        }
    }
}
