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
    public partial class UpdateImage : System.Web.UI.Page
    {
        Image_Data mImageData = new Image_Data();
        User_Data mUserData = new User_Data();
        Album_Data mAlbumData = new Album_Data();
        Image_Bus mImage = new Image_Bus();
        Album_Bus mAlbum = new Album_Bus();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_data"] == null || Request.QueryString["imageId"] == null)
            {
                Response.Redirect("default.aspx");
            }

            mUserData = (User_Data)Session["user_data"];

            long imageId = Convert.ToInt64(Request.QueryString["imageId"]);
            mImage.GetImageByImageId(imageId, ref mImageData);
            mAlbum.GetAlbumByAlbumId(mImageData.albumId, ref mAlbumData);

            if(mUserData.userId!=mAlbumData.userId)
                Response.Redirect("default.aspx");

            if (!Page.IsPostBack)
            {
                descriptionsTB.Text = mImageData.descriptions;
                imageTypeDDL.Text = mImageData.imageType;
            }
        }

        protected void enSureB_Click(object sender, EventArgs e)
        {
            mImageData.descriptions = descriptionsTB.Text.ToString();
            mImageData.imageType = imageTypeDDL.Text.ToString();


            mImage.UpdateImage(ref mImageData, imageUrlFU);
            Response.Redirect("ImageHome.aspx?imageId="+Convert.ToString(mImageData.imageId));
        }

        protected void ReturnImageHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImageHome.aspx?imageId=" + Convert.ToString(mImageData.imageId));
        }
    }
}
