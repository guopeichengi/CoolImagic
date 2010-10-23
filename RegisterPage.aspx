<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterPage.aspx.cs" Inherits="RegisterPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CI - Register</title>
    <link href="CSS/topLogo.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/RegisterBody.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainWidth topLogo">
        <div class="searchButton">
            <asp:Button ID="SearchButton" runat="server" Text="Search" Height="25px" Width="75px" ValidationGroup="SearchVG" />
        </div>
        <div class="searchBox">
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="SearchBox" ValidationGroup="SearchVG"></asp:RequiredFieldValidator>
            <asp:TextBox ID="SearchBox" runat="server" Height="20px" Width="125px" ValidationGroup="SearchVG"></asp:TextBox>
        </div>
    </div>
    
    <div class="navi">
        &nbsp;&nbsp;>>
        <asp:Label ID="backToHomePage" runat="server" Text="返回首页"></asp:Label>
    </div>
    
    <div class="mainWidth registerBody">
        <br />
        <br />
        <fieldset class="fs_border"><legend>注册 - 开通你的专属账户</legend>
            <br />
            <div class="tableDiv">
                <table class="registerTable">
                    <tbody>
                        <tr class="row1">
                            <td class="right">我的用户名：</td>
                            <td class="left">
                                <asp:TextBox ID="reUserName" runat="server" ValidationGroup="registerVG"></asp:TextBox>
                            </td>
                            <td class="left" id="cssTest">（用户名不得少于4个字符...）</td>
                        </tr>
                        <tr class="row2">
                            <td></td>
                            <td class="left">
                                <asp:Button ID="singleTestButton" runat="server" Text="我是独一无二的吗？" Height="30px" 
                                    Width="125px" />
                            </td>
                            <td></td>
                        </tr>
                        
                        <tr class="row1">
                            <td></td>
                            <td class="left">
                                <asp:RequiredFieldValidator ID="reUserNameRFV" runat="server" 
                                    ErrorMessage="用户名不能为空" ControlToValidate="reUserName" 
                                    ValidationGroup="registerVG"></asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr>
                        
                        <tr class="row2">
                            <td class="right" width="140px">我的密码：</td>
                            <td class="left">
                                <asp:TextBox ID="rePwd" runat="server" ValidationGroup="registerVG"></asp:TextBox>
                            </td>
                            <td class="left">（密码设置说明）</td>
                        </tr>
                        
                        <tr class="row1">
                            <td class="right">重复密码：</td>
                            <td class="left">
                                <asp:TextBox ID="affirmRePwd" runat="server" ValidationGroup="registerVG"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        
                        <tr class="row2">
                            <td></td>
                            <td class="left">
                                <asp:RequiredFieldValidator ID="rePwdRFV" runat="server" 
                                    ErrorMessage="忘记写密码了！" ControlToValidate="rePwd" 
                                    ValidationGroup="registerVG"></asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr> 
                    </tbody>
                </table>
                <br />
                
                <table class="registerTable">
                    <tbody>
                        <tr class="row1">
                            <td class="right" width="140px">注册说明：</td>
                            <td class="left">
                                <asp:TextBox ID="declare" runat="server" Height="150px" Width="350px">注册说明内容，是否可滚动之类的待定</asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr class="row2">
                            <td></td>
                            <td class="left">
                                <asp:RadioButtonList ID="agreeOrNot" runat="server">
                                    <asp:ListItem>不同意</asp:ListItem>
                                    <asp:ListItem>我已阅读说明且同意</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        
                        <tr class="row1">
                            <td></td>
                            <td class="left">
                                <asp:Button ID="Register" runat="server" Text="立刻注册" Height="30px" 
                                Width="100px" ValidationGroup="registerVG" />
                                <asp:Button ID="Reset" runat="server" Text="填错了，重填全部" Height="30px" Width="125px" />
                                </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </fieldset>
    </div>
    
    <div class="navi">
        &nbsp;&nbsp;>>
        <asp:Label ID="Label1" runat="server" Text="返回首页"></asp:Label>
    </div>
    
    <hr />
    <div class="mainWidth">
        Copyright ......
    </div>
    </form>
</body>
</html>