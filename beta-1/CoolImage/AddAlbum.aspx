<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAlbum.aspx.cs" Inherits="CoolImage.AddAlbum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>创建相册——Cool Imagic</title>
    <link href="css/userpage2.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong>相册名：</strong><asp:TextBox ID="albumNameTB" runat="server"></asp:TextBox>
        <br /><br />
        <strong>权限：</strong><asp:TextBox ID="permissionTB" runat="server"></asp:TextBox>
        <br /><br />
        <strong>相册logo：</strong><asp:FileUpload ID="albumLogoFU" runat="server" />
        <br /><br />
        <strong>相册描述：</strong><asp:TextBox ID="descriptionTB" runat="server" Height="169px" 
            TextMode="MultiLine" Width="297px"></asp:TextBox>
        <br /><br />
        <div class="bottom">
        <asp:Button ID="ensureB" runat="server" onclick="ensureB_Click" Text="确定" />
        &emsp;&emsp;
        <asp:LinkButton ID="ReturnHomeLB" runat="server" onclick="ReuturnHomeLB_Click">返回用户主页</asp:LinkButton>
        </div>
    
    </div>
    </form>
</body>
</html>
