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
    public partial class AlbumHome : System.Web.UI.Page
    {
        Image_Bus mImage = new Image_Bus();
        User_Bus mUser = new User_Bus();
        Album_Data album_data = new Album_Data();
        User_Data user_data = new User_Data();
        AlbumComment_Bus mComment = new AlbumComment_Bus();
        Album_Bus mAlbum = new Album_Bus();

        long albumId;

        DataTable imageList;
        DataTable commentList;

        User_Data userOfThisPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["albumId"] == null)
            {
                Response.Redirect("Default.aspx",true);
                return;
            }

            albumId = Convert.ToInt64(Request.QueryString["albumId"]);
            mAlbum.GetAlbumByAlbumId(albumId, ref album_data);

            AlbumNameL.Text = album_data.albumName;
            AlbumLogoI.ImageUrl = album_data.logoUrl;
            AlbumDescriptionsL.Text = album_data.descriptions;

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

            imageList = mImage.ViewImageListByAlbumId(album_data.albumId);
            commentList = mComment.ViewAlbumCommentByAlbumId(album_data.albumId);

            if (!Page.IsPostBack)
            {
                GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                GridView3.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

                GridView3.DataSource = commentList;
                GridView3.DataBind();

                GridView1.DataSource = imageList;
                GridView1.DataBind();
            }
        }

        protected void addNewImageLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddImage.aspx?albumId="+Convert.ToString(albumId),true);
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("delete"))
            {
                long i = Convert.ToInt64(e.CommandArgument);
                mComment.DeleteAlbumCommentByCommentId(i);
                Response.Redirect("AlbumHome.aspx?albumId=" + Convert.ToString(albumId));
            }
        }

        protected void ensureAdd_Click(object sender, EventArgs e)
        {
            if (Session["user_data"] == null)
                mComment.AddAlbumComment(album_data.albumId, userCommentTB.Text.ToString(), "游客");
            else
                mComment.AddAlbumComment(album_data.albumId, userCommentTB.Text.ToString(), user_data.userName);

            Response.Redirect("AlbumHome.aspx?albumId=" + Convert.ToString(albumId));
        }

        protected void updateAlbumLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAlbum.aspx?albumId=" + Convert.ToString(albumId),true);
        }

        protected void deleteAlbumLB_Click(object sender, EventArgs e)
        {   
            
            mAlbum.DeleteAlbumByAlbumId(album_data.albumId,user_data.userLoginName,album_data.albumName);
            Response.Redirect("Home.aspx?userId="+Convert.ToString(user_data.userId),true);
        }

        protected void ReturnHomeLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?userId=" + Convert.ToString(userOfThisPage.userId), true);
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = commentList;
            GridView3.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = imageList;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("viewImage"))
            {
                Response.Redirect("ImageHome.aspx?imageId=" + Convert.ToString(e.CommandArgument), true);
            }
        }

    }
}
