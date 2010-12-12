﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateImage.aspx.cs" Inherits="CoolImage.UpdateImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改图片信息——Cool Imagic</title>
    <link href="css/userpage2.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>上传图片文件：</strong><asp:FileUpload ID="imageUrlFU" runat="server" />
        <br /><br />
        <strong>类型：</strong><asp:DropDownList ID="imageTypeDDL" runat="server">
            <asp:ListItem>动物</asp:ListItem>
            <asp:ListItem>风景</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>
            <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        <br /><br />
        <strong>描述：</strong><asp:TextBox ID="descriptionsTB" runat="server" Height="179px" Width="351px"></asp:TextBox>
        <br /><br />
        <div class="bottom">
            <asp:Button ID="enSureB" runat="server" onclick="enSureB_Click" Text="确定" />
            &emsp;&emsp;
            <asp:LinkButton ID="ReturnImageHomeLB" runat="server" 
            onclick="ReturnImageHomeLB_Click">返回</asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>