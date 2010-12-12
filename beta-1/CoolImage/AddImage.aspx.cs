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
    public partial class AddImage : System.Web.UI.Page
    {
        Image_Data mImageData = new Image_Data();
        Image_Bus mImage = new Image_Bus();
        User_Data mUserData = new User_Data();
        Album_Data mAlbumData = new Album_Data();
        Album_Bus mAlbum = new Album_Bus();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_data"] == null || Request.QueryString["albumId"] == null)
            {
                Response.Redirect("Default.aspx",true);
                return;
            }
            
            mUserData = (User_Data)Session["user_data"];
            long albumId = Convert.ToInt64(Request.QueryString["albumId"]);
            mAlbum.GetAlbumByAlbumId(albumId, ref mAlbumData);
        }

        protected void enSureB_Click(object sender, EventArgs e)
        {

            if (!mImage.CheckImageNameUnique(imageNameTB.Text.ToString(),mAlbumData.albumId))
            {
                Response.Write("<script>alert('图片名重复！');</script>");
                return;
            }

            mImageData.albumId = mAlbumData.albumId;
            mImageData.createDate = "";
            mImageData.descriptions = descriptionsTB.Text.ToString();
            mImageData.imageName = imageNameTB.Text.ToString();
            mImageData.imageType = imageTypeDDL.Text.ToString();

            mImage.AddImage(ref mImageData, mUserData.userLoginName, mAlbumData.albumName, imageUrlFU);
            Response.Redirect("AlbumHome.aspx?albumId="+Convert.ToString(mAlbumData.albumId),true);
        }

        protected void ReturnAlbumHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlbumHome.aspx?albumId=" + Convert.ToString(mAlbumData.albumId), true);
        }

       
    }
}
