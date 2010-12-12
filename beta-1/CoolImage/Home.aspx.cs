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
    public partial class Home : System.Web.UI.Page
    {
        private User_Data mUser_Data;
        private Album_Bus mAlbum = new Album_Bus();
        private User_Bus mUser = new User_Bus();
        private UserComment_Bus mComment = new UserComment_Bus();

        private DataTable albumList;
        private DataTable commentList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userId"] == null)
            {
                Response.Redirect("Default.aspx",true);
                return;
            }

            long userId = Convert.ToInt64(Request.QueryString["userId"]);

            if (Session["user_data"] == null)
            {
                UserAreaP.Visible = false;
                mUser.GetUserDataByUserId(userId, ref mUser_Data);
            }
            else
            {
                mUser_Data = (User_Data)Session["user_data"];
                if (mUser_Data.userId != userId)
                {
                    UserAreaP.Visible = false;
                }
            }

            albumList = mAlbum.ViewAlbumListByUserId(userId);
            commentList = mComment.ViewUserCommentByUserId(userId);

            if (!Page.IsPostBack)
            {
                UserLogoI.ImageUrl = mUser_Data.logoUrl;
                UserNameL.Text = mUser_Data.userName;
                UserDescriptionL.Text = mUser_Data.descriptions;
                UserSexL.Text = mUser_Data.sex;

                GridView1.DataSource = albumList;
                GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                GridView1.DataBind();

                GridView3.DataSource = commentList;
                GridView3.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                GridView3.DataBind();
            }
            
        }

        protected void addAlbumLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAlbum.aspx");
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("viewAlbum"))
            {
                long i = Convert.ToInt64(e.CommandArgument);
                Album_Data album_data = new Album_Data();
                mAlbum.GetAlbumByAlbumId(i, ref album_data);
                Response.Redirect("AlbumHome.aspx?albumId=" + Convert.ToString(album_data.albumId), true);
            }
        }

        protected void ensureAdd_Click(object sender, EventArgs e)
        {
            if (Session["user_data"] != null)
                mUser_Data = (User_Data)Session["user_data"];
            else
                mUser_Data.userName = "游客";

            long userId = Convert.ToInt64(Request.QueryString["userId"]);
            mComment.AddUserComment(userId,userCommentTB.Text.ToString(),mUser_Data.userName);
            Response.Redirect("Home.aspx?userId=" + Convert.ToString(Request.QueryString["userId"]), true);
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("delete"))
            {
                mUser_Data = (User_Data)Session["user_data"];
                long i = Convert.ToInt64(e.CommandArgument);
                mComment.DeleteUserCommentByCommentId(i);
                Response.Redirect("Home.aspx?userId=" + Convert.ToString(Request.QueryString["userId"]), true);
            }
        }

        protected void updateUserLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUser.aspx");
        }

        protected void deleteUserLB_Click(object sender, EventArgs e)
        {
            mUser.DeleteUser(mUser_Data.userLoginName,mUser_Data.userId);
            Session["user_data"] = null;
            Response.Redirect("Default.aspx",false);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource =albumList;
            GridView1.DataBind();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = commentList;
            GridView3.DataBind();
        }



     
    }
}
