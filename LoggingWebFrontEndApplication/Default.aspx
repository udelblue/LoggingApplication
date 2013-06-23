<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LoggingWebFrontEndApplication._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <br />
    
    Title:<br />
    <asp:TextBox ID="TextBoxTitle" runat="server" ToolTip="Title" Width="258px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    Category:<br />
    <asp:TextBox ID="TextBoxCategory" runat="server" ToolTip="Title" Width="258px"></asp:TextBox>
    &nbsp;<br />
    &nbsp;&nbsp;&nbsp;
    <br />
    Priority:<br />
    <asp:DropDownList ID="DropDownListPriority" runat="server">
        <asp:ListItem>Low</asp:ListItem>
        <asp:ListItem>Normal</asp:ListItem>
        <asp:ListItem>High</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    Message:<br />

    <asp:TextBox ID="TextBoxMessage" runat="server" Height="119px" 
        ToolTip="Message" Width="604px" ontextchanged="TextBoxMessage_TextChanged"></asp:TextBox>

    <br />

    <br />
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
    onclick="ButtonSubmit_Click" />
    


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="NotifyLabel" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    


    </asp:Content>
