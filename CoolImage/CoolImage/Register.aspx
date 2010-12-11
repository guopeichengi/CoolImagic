<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CoolImage.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>注册——Cool Imagic</title>
    <link href="css/userpage.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>用户名：</td>
            <td><asp:TextBox ID="userLoginNameTB" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>密码：</td>
            <td><asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
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
            <td>出生日期：</td>
            <td><asp:DropDownList ID="YDDL" runat="server" 
                    onselectedindexchanged="YDDL_SelectedIndexChanged">
                <asp:ListItem>1989</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="MDDL" runat="server">
                <asp:ListItem Value="09">09</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DDDL" runat="server">
                <asp:ListItem>08</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>MSN：<asp:TextBox ID="MSNTB" runat="server"></asp:TextBox>
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
            <td>密码问题1：</td>
            <td><asp:TextBox ID="question1TB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>问题答案1：</td>
            <td><asp:TextBox ID="answer1TB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>密码问题2：</td>
            <td><asp:TextBox ID="question2TB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>问题答案2：</td>
            <td><asp:TextBox ID="answer2TB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>密码问题3：</td>
            <td><asp:TextBox ID="question3TB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>问题答案3：</td>
            <td><asp:TextBox ID="answer3TB" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>用户描述：</td>
            <td><asp:TextBox ID="descriptionTB" runat="server" Height="80px" 
            TextMode="MultiLine" Width="500px"></asp:TextBox></td>
        </tr>
        </table>
        <br />
        &emsp;<asp:Button ID="registerSureTB" runat="server" onclick="registerSureTB_Click" 
            Text="确认注册" />
        &emsp;&emsp;<asp:Button ID="CancelB" runat="server" onclick="CancelB_Click" Text="取消" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="userId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="userId" HeaderText="userId" InsertVisible="False" 
                    ReadOnly="True" SortExpression="userId" />
                <asp:BoundField DataField="userLoginName" HeaderText="userLoginName" 
                    SortExpression="userLoginName" />
                <asp:BoundField DataField="userPassword" HeaderText="userPassword" 
                    SortExpression="userPassword" />
                <asp:BoundField DataField="userName" HeaderText="userName" 
                    SortExpression="userName" />
                <asp:BoundField DataField="sex" HeaderText="sex" SortExpression="sex" />
                <asp:BoundField DataField="birth" HeaderText="birth" SortExpression="birth" />
                <asp:BoundField DataField="MSN" HeaderText="MSN" SortExpression="MSN" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="logoUrl" HeaderText="logoUrl" 
                    SortExpression="logoUrl" />
                <asp:BoundField DataField="question1" HeaderText="question1" 
                    SortExpression="question1" />
                <asp:BoundField DataField="answer1" HeaderText="answer1" 
                    SortExpression="answer1" />
                <asp:BoundField DataField="question2" HeaderText="question2" 
                    SortExpression="question2" />
                <asp:BoundField DataField="answer2" HeaderText="answer2" 
                    SortExpression="answer2" />
                <asp:BoundField DataField="question3" HeaderText="question3" 
                    SortExpression="question3" />
                <asp:BoundField DataField="answer3" HeaderText="answer3" 
                    SortExpression="answer3" />
                <asp:BoundField DataField="descriptions" HeaderText="descriptions" 
                    SortExpression="descriptions" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" Height="50px" 
                            ImageUrl='<%# Eval("logoUrl") %>' Width="60px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <asp:Image ID="Image1" runat="server" Height="65px" 
                    ImageUrl='<%# Eval("logoUrl") %>' />
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CoolImageConnectionString %>" 
            SelectCommand="SELECT * FROM [Users]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
