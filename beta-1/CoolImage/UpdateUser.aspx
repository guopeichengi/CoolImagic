<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="CoolImage.UpdateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改用户资料————Cool Imagic</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>昵称：</td>
            <td><asp:TextBox ID="userNameTB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>性别：</td>
            <td><asp:DropDownList ID="sexDDL" runat="server">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>MSN：</td>
            <td><asp:TextBox ID="MSNTB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email：</td>
            <td><asp:TextBox ID="EmailTB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>头像上传：</td>
            <td><asp:FileUpload ID="userLogoFU" runat="server" /></td>
        </tr>
        <tr>
            <td>用户描述：</td>
            <td><asp:TextBox ID="descriptionTB" runat="server" Height="80px" 
                TextMode="MultiLine" Width="500px"></asp:TextBox></td>
        </tr>
    </table>
 
        
        <br />
        <asp:Button ID="ensureUpdateB" runat="server" onclick="ensureUpdateB_Click" 
            Text="确定更新" />
        <br />
        <br />
        <asp:LinkButton ID="ReturnHomeLB" runat="server" onclick="ReuturnHomeLB_Click">返回用户主页</asp:LinkButton>
        <br />
    </div>
    </form>
</body>
</html>
