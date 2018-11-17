﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Login" %>
<%@ Register TagPrefix= "cap" TagName="usercon" src="CaptchaUserControl.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><asp:Image ID="ElecIcon" runat="server" Height="60px" ImageUrl="~/App_Images/ElecIcon.jpg" Width="44px" />
        &nbsp;&nbsp; Login Page &nbsp;<asp:Image ID="FuelIcon" runat="server" Height="60px" ImageUrl="~/App_Images/FuelIcon.jpg" Width="44px" /></h1>
        <p> If you are new, please enter a UserID, Password, Captcha, and  select Create Account </p>

      </div> 
      <div class="row">  
        <div class="col-md-6">  
            User ID:&nbsp;<asp:TextBox ID="txtId" runat="server" Width="284px"></asp:TextBox> <br /><br />
            Password:&nbsp; <asp:TextBox ID="txtPasswd" runat="server" TextMode="Password" Width="284px"></asp:TextBox><br /><br />
            <cap:usercon ID="captcha" runat="server" />
         </div>
         <div class="col-md-6">             
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" style="text-align:center"/><br /><br />
            <asp:Button ID="btnCreateId" runat="server" Text="Create Account" OnClick="btnCreateId_Click" style="text-align:center"/><br /><br />
            <asp:Button ID="btnExit" runat="server" Text="Cancel" OnClick="btnExit_Click" style="text-align:center"/><br /><br />
           
         </div>
      </div>
      <div class ="row">
         <div class="col-md-12"> 
            <h2><asp:Label ID="lbldbg" runat="server" Text="Debug stuff here" style="COLOR: red"></asp:Label></h2>
          </div>
      </div>
      
    
</asp:Content>