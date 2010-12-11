<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumHome.aspx.cs" Inherits="CoolImage.AlbumHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>浏览相册——Cool Imagic</title>
    <link href="css/userpage.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="top"> 
        <asp:Panel ID="UserAreaP" runat="server">
            你好，<asp:Label ID="UserAreaName" runat="server"></asp:Label>
            &nbsp;
            <asp:LinkButton ID="addNewImageLB" runat="server" onclick="addNewImageLB_Click">添加图片</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="updateAlbumLB" runat="server" onclick="updateAlbumLB_Click">编辑相册</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="deleteAlbumLB" runat="server" onclick="deleteAlbumLB_Click">删除相册</asp:LinkButton>
&nbsp;
        </asp:Panel>  
        </div>
        <div class="Logo">      <!--logo行-->
            <div class="search">
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="SearchBox" ValidationGroup="SearchVG"></asp:RequiredFieldValidator>
                <asp:TextBox ID="SearchBox" runat="server" Height="15px" Width="125px" ValidationGroup="SearchVG"></asp:TextBox>
                <asp:Button ID="SearchButton" runat="server" Text="Search" Height="25px" Width="75px" ValidationGroup="SearchVG" />
            </div>
            
            <div class="user_info"><!--左侧用户资料部分-->
               <br />
                <asp:Image ID="UserLogoI" runat="server" Height="162px" Width="159px" /><br/><br/>
                用户名：<asp:Label ID="UserNameL" runat="server"></asp:Label>
                <br />
                性别：<asp:Label ID="UserSexL" runat="server"></asp:Label>
                <br />
                用户描述：<asp:Label ID="UserDescriptionsL" runat="server"></asp:Label>
            </div>
            
            <div class="rightpart">相册信息：<br />
                <br />
                &nbsp;
                <asp:Image ID="AlbumLogoI" runat="server" Height="161px" 
            Width="161px" />
            <br />
                <br />
             相册名：<asp:Label ID="AlbumNameL" runat="server"></asp:Label>
        
        <br />
        描述：<asp:Label ID="AlbumDescriptionsL" runat="server"></asp:Label>
            </div>
            
        </div>
        <div class="navigation">     <!--导航栏-->
            <ul class="navi_list">
                <li class="navi_button">当前位置:
                </li>
                <li class="navi_button">
                    <asp:LinkButton ID="ReturnHomeLB" runat="server" onclick="ReturnHomeLB_Click">个人主页 ></asp:LinkButton>
                </li>
                <li class="navi_current">个人相册
                </li>
            </ul>
        </div>
        <div class="middle2" align="center">   <!--中间部分，即各个页面中不同的部分-->
    
    <asp:GridView ID="GridView1" runat="server" onrowcommand="GridView1_RowCommand" 
        AllowPaging ="True" PageSize="5" AutoGenerateColumns="False" 
        onpageindexchanging="GridView1_PageIndexChanging" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="251px">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:TemplateField HeaderText="logo">
                <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="127px" 
                            ImageUrl='<%# Eval("imageUrl") %>' Width="161px" />
                        <br />
                        <asp:LinkButton ID="LinkButton4" runat="server" 
                            CommandArgument='<%# Eval("imageId") %>' CommandName='<%# "viewImage" %>'>浏览图片</asp:LinkButton>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="图片信息">
                <ItemTemplate>
                    <div style="height: 40px; width: 381px" align="left">
                        图片名：<asp:Label ID="Label1" runat="server" Text='<%# Eval("imageName") %>'></asp:Label>
                        <br />
                        类型：<asp:Label ID="Label5" runat="server" Text='<%# Eval("imageType") %>'></asp:Label>
                    </div>
                    <div style="height: 89px; width: 381px; margin-right: 0px; margin-top: 9px;" 
                        align="left">
                        图片描述：<br />
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("descriptions") %>'></asp:Label>
                       
                    </div>
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
            <br />
            <br />
        </div>
        <div class="review"><!--图片评论-->
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" onpageindexchanging="GridView3_PageIndexChanging" 
                onrowcommand="GridView3_RowCommand" PageSize="5" style="margin-right: 0px" 
                Width="549px">
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
                                用户：<asp:Label ID="Label7" runat="server" Text='<%# Eval("fromUser") %>'></asp:Label>
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
            <hr/>
            <br />
            <asp:TextBox ID="userCommentTB" runat="server" Height="161px" TextMode="MultiLine" 
                Width="550px"></asp:TextBox><br/><br/>
            <asp:Button ID="Button3" runat="server" Text="发表评论" />
        </div>
        
    </div>
    </form>
</body>
</html>
