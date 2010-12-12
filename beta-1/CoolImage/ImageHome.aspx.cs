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
using CoolImage_Bus.Comment;

namespace CoolImage
{
    public partial class ImageHome : System.Web.UI.Page
    {
        private Image_Data image_data = new Image_Data();
        private User_Data user_data = new User_Data();
        private User_Data userOfThisPage = new User_Data();
        private Album_Bus mAlbum = new Album_Bus();
        private User_Bus mUser = new User_Bus();
        private Album_Data album_data = new Album_Data();
        private Image_Bus mImage = new Image_Bus();
        private ImageComment_Bus mComment = new ImageComment_Bus();

        DataTable commentList;

        private long imageId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["imageId"] == null)
            {
                Response.Redirect("default.aspx", true);
            }

            imageId = Convert.ToInt64(Request.QueryString["imageId"]);
            mImage.GetImageByImageId(imageId, ref image_data);
            imageI.ImageUrl = image_data.imageUrl;
            ImageNameL.Text = image_data.imageName;
            ImageDescriptionL.Text = image_data.descriptions;
            ImageTypeL.Text = image_data.imageType;

            mAlbum.GetAlbumByAlbumId(image_data.albumId, ref album_data);
            mUser.GetUserDataByUserId(album_data.userId, ref userOfThisPage);

            UserLogoI.ImageUrl = userOfThisPage.logoUrl;
            UserNameL.Text = userOfThisPage.userName;
            UserSexL.Text = userOfThisPage.sex;
            UserDescriptionsL.Text = userOfThisPage.descriptions;

            if (Session["user_data"] == null)
            {
                UserAreaP.Visible = false;
            }
            else
                user_data = (User_Data)Session["user_data"];

            if (user_data.userId != album_data.userId)
            {
                UserAreaP.Visible = false;
            }
            else
            {
                UserAreaNameL.Text = user_data.userName;
            }

            commentList = mComment.ViewImageCommentByImageId(image_data.imageId);
            if (!Page.IsPostBack)
            {
                GridView3.DataSource = commentList;
                GridView3.DataBind();
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("delete"))
            {
                long i = Convert.ToInt64(e.CommandArgument);
                mComment.DeleteImageCommentByCommentId(i);
                Response.Redirect("ImageHome.aspx?imageId=" + Convert.ToString(imageId));
            }
        }

        protected void ensureAdd_Click(object sender, EventArgs e)
        {
            if(Session["user_data"] != null)
                mComment.AddImageComment(image_data.imageId, userCommentTB.Text.ToString(), user_data.userName);
            else
                mComment.AddImageComment(image_data.imageId, userCommentTB.Text.ToString(), "游客");
            Response.Redirect("ImageHome.aspx?imageId=" + Convert.ToString(imageId));
        }

        protected void updateImageLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateImage.aspx?imageId=" + Convert.ToString(imageId));
        }

        protected void deleteImageLB_Click(object sender, EventArgs e)
        {
            mImage.DeleteImageByImageIdImageUrl(image_data.imageId, image_data.imageUrl);
            Response.Redirect("AlbumHome.aspx?albumId="+Convert.ToInt64(album_data.albumId),true);
        }

        protected void ReturnAlbumHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlbumHome.aspx?albumId=" + Convert.ToInt64(album_data.albumId), true);
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = commentList;
            GridView3.DataBind();
        }

        protected void ReturnHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?userId=" + Convert.ToString(userOfThisPage.userId), true);
        }


    }
}
