<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageHome.aspx.cs" Inherits="CoolImage.ImageHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>浏览图片——Cool Imagic</title>
    <link href="css/userpage.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
<div class="main">
        <div class="top">
         <asp:Panel ID="UserAreaP" runat="server" Height="16px" 
                style="margin-top: 8px; margin-bottom: 12px">
             &nbsp; 你好，<asp:Label ID="UserAreaNameL" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="updateImageLB" runat="server" 
                 onclick="updateImageLB_Click">编辑图片</asp:LinkButton>
             &nbsp;&nbsp;<asp:LinkButton ID="deleteImageLB" runat="server" 
                 onclick="deleteImageLB_Click">删除图片</asp:LinkButton>
             &nbsp;
        </asp:Panel>   
        </div>
        <div class="Logo">      <!--logo行-->
            <div class="search">
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="SearchBox" ValidationGroup="SearchVG"></asp:RequiredFieldValidator>
                <asp:TextBox ID="SearchBox" runat="server" Height="20px" Width="126px" 
                    ValidationGroup="SearchVG"></asp:TextBox>
                &nbsp;
                <asp:Button ID="SearchButton" runat="server" Text="Search" Height="22px" 
                    Width="75px" ValidationGroup="SearchVG" style="margin-top: 1px" />
            </div>
            
            <div class="user_info"><!--左侧-->
                <br />
                <asp:Image ID="UserLogoI" runat="server" Height="162px" Width="159px" /><br/><br/>
                用户名：<asp:Label ID="UserNameL" runat="server"></asp:Label>
                <br />
                性别：<asp:Label ID="UserSexL" runat="server"></asp:Label>
                <br />
                用户描述：<asp:Label ID="UserDescriptionsL" runat="server"></asp:Label>
             </div>
            
            <div class="rightpart"><!--右侧-->
                &nbsp;
                <br />&nbsp; 图片信息：<br />
                &nbsp;
                图片名：<asp:Label ID="ImageNameL" runat="server"></asp:Label>
                <br />
                &nbsp;
                图片类型：<asp:Label ID="ImageTypeL" runat="server"></asp:Label>
                &nbsp;<br />
                &nbsp;
                图片描述：<br />
&nbsp; <asp:Label ID="ImageDescriptionL" runat="server"></asp:Label>
            <br />
            </div>
            
        </div>
        <div class="navigation">     <!--导航栏-->
            <ul class="navi_list">
                <li class="navi_button">当前位置:
                </li>
                <li class="navi_button">     <!--非当前页，链接到相应页-->
                    <asp:LinkButton ID="ReturnHomeLB" runat="server" onclick="ReturnHomeLB_Click">个人主页 ></asp:LinkButton>
                </li>
                <li class="navi_button"><asp:LinkButton ID="ReturnAlbumHomeLB" runat="server" 
                    onclick="ReturnAlbumHomeLB_Click">相册主页 ></asp:LinkButton>
                </li>
                <li class="navi_current">图片主页<!--当前页-->
                </li>
            </ul>
        </div>
        <div class="middle" align="center">   <!--中间部分，即各个页面中不同的部分-->
            <br />
            <asp:Image ID="imageI" runat="server" Height="409px" Width="535px" />
            <br />
        </div>
        <div class="review"><!--图片评论-->
            评论：<br />
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onpageindexchanging="GridView3_PageIndexChanging" 
            onrowcommand="GridView3_RowCommand" PageSize="5" Width="549px"
                style="margin-right: 0px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="删除">
                    <EditItemTemplate>
                        &nbsp;
                    </EditItemTemplate>
                    <FooterTemplate>
                        &nbsp;
                    </FooterTemplate>
                    <HeaderTemplate>
                        用户评论
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="height: 82px; width: 399px; margin-bottom: 0px; text-align:left">
                            用户：<asp:Label ID="Label5" runat="server" Text='<%# Eval("fromUser") %>'></asp:Label>
                            <br />
                            评论：<asp:Label ID="Label6" runat="server" Text='<%# Eval("commentText") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                    <HeaderTemplate>
                        删除
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" 
                            CommandArgument='<%# Eval("commentId") %>' CommandName='<%# "delete" %>'>删除 
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            <br/><br/>
            <hr/>
            <br />
            <asp:TextBox ID="userCommentTB" runat="server"  Height="128px" 
                TextMode="MultiLine" Width="546px"></asp:TextBox><br/><br/>
            <asp:Button ID="ensureAdd" runat="server" onclick="ensureAdd_Click"  Text="添加评论" />
        </div>
        
    </div>
    </form>
</body>
</html>
