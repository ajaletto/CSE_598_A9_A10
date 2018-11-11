<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aletto_Doyal_A9_A10._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron"style="text-align:center">
        <h1><asp:Image ID="ElecIcon" runat="server" Height="60px" ImageUrl="~/App_Images/ElecIcon.jpg" Width="44px" />
        &nbsp;&nbsp; Welcome to the Aletto-Doyal Alternative Fuels Site &nbsp;<asp:Image ID="FuelIcon" runat="server" Height="60px" ImageUrl="~/App_Images/FuelIcon.jpg" Width="44px" />
        </h1>
        <p class="lead">From this site, you will be able to search for alternative and gasoline fuel sources<br />
                        as well as allow you to identify a route that we can provide you with Electric car charging stations.
        </p>
       <p>
           To use our services, we request that you create a user account.  <br />
           The account will require a unique user name and password.  
       </p>
        <p>
            Please select the &quot;Members&quot; button below to begin your adventure using our services.</p>
        <p>
            The Staff Onlly button is for the TA&#39;s to be able to test the complete site using our </p>
        <p>
            Service Directory and TryIt pages.&nbsp; The Service directory button on the Main page will be activated for Staff Only.</p>
        <p>
            <asp:Button ID="btnMember" runat="server" Text="Members" OnClick="btnMember_Click" />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Button ID="brnStaff" runat="server" Text="Staff Onlly" OnClick="brnStaff_Click" />
       </p>
        <asp:Label ID="lblDebug" runat="server" Text="Debug stuff here" style="COLOR: red"></asp:Label>
    </div>
</asp:Content>