<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ImageHome2.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head id="Head1" runat="server">
    <title>浏览图片——Cool Imagic</title>
    <link href="css/userpage.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="top"> 
         <asp:Panel ID="UserAreaP" runat="server">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="addAlbumLB_Click">创建相册</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="updateUserLB_Click">编辑用户</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="deleteUserLB_Click">删除用户</asp:LinkButton>
        </asp:Panel>
        </div>
        <div class="Logo">      <!--logo行-->
            <div class="search">
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="SearchBox" ValidationGroup="SearchVG"></asp:RequiredFieldValidator>
                <asp:TextBox ID="SearchBox" runat="server" Height="15px" Width="125px" ValidationGroup="SearchVG"></asp:TextBox>
                <asp:Button ID="SearchButton" runat="server" Text="Search" Height="25px" Width="75px" ValidationGroup="SearchVG" />
            </div>
            
            <div class="user_info">
               <br />
                <asp:Image ID="UserLogoI" runat="server" Height="162px" Width="159px" /><br/><br/>  <!--用户头像-->
                用户名：<asp:Label ID="UserNameL" runat="server"></asp:Label><!--左侧用户资料部分-->
                <br />
                性别：<asp:Label ID="UserSexL" runat="server"></asp:Label>
                <br />
                用户描述：<asp:Label ID="UserDescriptionsL" runat="server"></asp:Label>
            </div>
            
            <div class="rightpart">            
            </div>
            
        </div>
        <div class="navigation">     <!--导航栏-->
            <ul class="navi_list">
                <li class="navi_button">
                    <asp:LinkButton ID="ReturnHomeLB" runat="server" onclick="ReturnHomeLB_Click">个人主页</asp:LinkButton>
                <li class="navi_current">个人相册<!--当前页-->
                </li>
            </ul>
        </div>
        <div class="middle2" align="center">   <!--中间部分，即各个页面中不同的部分-->
    
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" onpageindexchanging="GridView1_PageIndexChanging" 
                onrowcommand="GridView1_RowCommand" PageSize="5" Width="546px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:TemplateField HeaderText="logo">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="127px" 
                                ImageUrl='<%# Eval("logoUrl") %>' Width="161px" />
                            <br />
                            <asp:LinkButton ID="LinkButton4" runat="server" 
                                CommandArgument='<%# Eval("albumId") %>' CommandName='<%# "viewAlbum" %>'>浏览相册</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="相册信息">
                        <ItemTemplate>
                            <div style="height: 18px; width: 355px">
                                相册名：<asp:Label ID="Label1" runat="server" Text='<%# Eval("albumName") %>'></asp:Label>
                            </div>
                            <div style="height: 126px; width: 353px; margin-right: 0px;">
                                相册描述：<br />
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("descriptions") %>'></asp:Label>
                                <br />
                                <br />
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
                            <div style="height: 82px; width: 399px; margin-bottom: 0px;">
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
