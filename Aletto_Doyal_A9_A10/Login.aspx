<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron"style="text-align:center">
        <h1><asp:Image ID="ElecIcon" runat="server" Height="60px" ImageUrl="~/App_Images/ElecIcon.jpg" Width="44px" />
        &nbsp;&nbsp; Login Page &nbsp;<asp:Image ID="FuelIcon" runat="server" Height="60px" ImageUrl="~/App_Images/FuelIcon.jpg" Width="44px" />
        </h1>
        <p class="lead">If you are Member, please enter your credentials and  select Login<br />
                        If you are new, please enter a UserID and Password and select Create Account<br /><br />
            User ID:&nbsp;<asp:TextBox ID="txtId" runat="server" Width="284px"></asp:TextBox> <br /><br />
            
            Password:&nbsp; <asp:TextBox ID="txtPasswd" runat="server" Width="284px"></asp:TextBox><br /><br />
            
            <asp:Button ID="btnLogin" runat="server" Text="Login" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreateId" runat="server" Text="Create Account" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExit" runat="server" Text="Cancel" OnClick="btnExit_Click" />
            <br /><br />

            
       
        <asp:Label ID="lbldbg" runat="server" Text="Debug stuff here" style="COLOR: red"></asp:Label>

    </div>
</asp:Content>