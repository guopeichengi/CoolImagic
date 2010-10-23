<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cool Imagic - Home Page</title>
    <meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
    <style type="text/css">
        .top
        {
        	width:1000px;
        	height:70px;
        	background-image:url(a.jpg);
        	text-align:center;
        	margin:auto;
        	}
        .center
        {
        	width:1000px;
        	height:500px;
        	background-color:Gray;
        	text-align:center;
        	margin:auto;
        	}
        .bottom
        {
        	width:1000px;
        	height:200px;
        	background-color:Yellow;
        	margin:auto;
        	text-align:center;
            }
        .t_search
        {
        	float:right;
        	margin-top:35px;
           	margin-right:5px;
        	}
        .b_search
        {
        	float:right;
        	margin-top:35px;
        	margin-right:20px;
            }
        .picturebox
        {
        	float:left;
        	margin-left:40px;
        	margin-top:60px;
        	}
        .lrbox
        {
        	float:right;
        	margin-right:20px;
        	margin-top:60px;
        	width:400px;
        	height:400px;
        	background-color:Gray;
        	}
        .login
        {
        	margin-top:5px;
        	margin-left:20px;
        	width:360px;
        	height:300px;
        	background-color:Yellow;
        	}
        .register
        {
        	margin-top:5px;
        	margin-left:20px;
        	width:360px;
        	height:60px;
        	background-color:Red;
        	}
        .b_register
        {
        	Width:320px;
        	Height:40px;
        	margin-top:10px;
        	font-size:35px;
        	}
        fieldset
        {
        	font-size:25px;
        	}
        legend
        {
        	text-align:left;
        	}
        .login_align
        {
        	text-align:left;
        	}
        #Login
        {
        	font-size:25px;
        	}
    	.fo
    	{
    		font-size:medium;	
    		}
    </style>
        

</head>
<body>
    <form id="form1" runat="server">
    <div class ="top">
        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="b_search" />
        <asp:TextBox ID="SearchBox" runat="server" Width="155px" CssClass="t_search"></asp:TextBox>
    
    
    </div>
    <div class="center" >
    
        <asp:Image ID="PictureBox" runat="server" Height="400px" Width="500px" 
            CssClass="picturebox"/>
              
        <div class="lrbox">
            <div class="login">
                <fieldset>
                    <legend>登录</legend>
                    <div class="login_align">
                        用户名：<asp:TextBox ID="UserID" runat="server"></asp:TextBox><br/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserID"
                            ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
                        <br/>
                        密&nbsp; 码：<asp:TextBox ID="UserPwd" runat="server" 
                             TextMode ="Password"></asp:TextBox><br/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserPwd"
                            ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
                        <br/>
                        验证码：<asp:TextBox ID="Check" runat="server" Width="60px" MaxLength="4"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="35px" Width="117px" 
                            ImageUrl="~/ValitionNo.aspx"/>
                        <br/><br/>
                    </div>
                        <asp:Button ID="Login" runat="server" Text="登录" Height="32px" 
                        Width="72px" onclick="Login_Click" />
                        <asp:HyperLink ID="Forget" runat="server" >忘记密码</asp:HyperLink>
                    <asp:Label ID="Tips" runat="server" CssClass="fo"></asp:Label>
                </fieldset>
            </div>
            <br/>
            <div class="register">
                <asp:Button ID="Register" runat="server" Text="猛击注册" CssClass="b_register" />
            </div>
        </div>
    
    </div>
    
    <div class="bottom">
    </div>
    </form>
</body>
</html>
