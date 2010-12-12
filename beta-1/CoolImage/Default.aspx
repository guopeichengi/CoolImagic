<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CoolImage._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>首页——Cool Imagic</title>
    <link href="css/userpage.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class = "defaultmain">
        <asp:Image ID="Image1" runat="server" Height="215px" 
            style="margin-left: 0px; margin-top: 141px" Width="469px" 
            ImageUrl ="~/images/logo2.JPG"/>
        <br />
        <asp:TextBox ID="SearchTB0" runat="server" Height="26px" 
            style="margin-top: 60px; margin-left: 0px;" Width="279px"></asp:TextBox>
&nbsp;
        <asp:Button ID="SearchB0" runat="server" Text="搜图" Height="28px" Width="71px" />
    </div>
       <div style="background-color: #FFFFCC; width: 1000px; margin:0px auto auto auto; height: 32px; ">
        <asp:Panel ID="UserAreaP" runat="server" BorderStyle="Dotted" Height="31px" style="margin-top: 0px"
               BorderWidth="1px">
            你好，<asp:Label ID="UserNameL" runat="server" style="margin-top: 2px"></asp:Label>
            &nbsp;<asp:LinkButton ID="MyHomeLB" runat="server" onclick="MyHomeLB_Click">我的主页</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="ExitLB" runat="server" onclick="ExitLB_Click">退出</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="TouristP" runat="server" BorderStyle="Dotted" BorderWidth="1px" 
               Height="31px" style="margin-top: 0px">
            用户名：<asp:TextBox ID="userLoginNameTB" runat="server" style="margin-top: 2px"></asp:TextBox>
            密码：<asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="userLoginNameB0" runat="server" onclick="userLoginNameB_Click" 
                Text="登录" />
            <asp:Button ID="registerB0" runat="server" onclick="Button1_Click" Text="注册" />
            <asp:LinkButton ID="FindPasswordLB0" runat="server">忘记密码？</asp:LinkButton>
        </asp:Panel>
    </div>
    <br />
    </form>
   
</body>
</html>
