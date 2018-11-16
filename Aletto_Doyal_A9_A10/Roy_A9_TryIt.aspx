
<%@ Page Title="Roy Assignment 9 TryIt" Language="C#"  validateRequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Roy_A9_TryIt.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Roy_A9_TryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Roy Doyal -- Assignment 9 TryIt</h2>
        <p class="lead">Testing Session Data, XML Read/Write, Hashing DLL</p>
        <p>Return to Index Page :&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://webstrar43.fulton.asu.edu/page0/index.html">http://webstrat43.fulton.asu.edu/page0/index.html</asp:HyperLink>
        </p>
    </div>

    <div class="row">
        <div class="col-md-6">&nbsp;&nbsp;&nbsp;&nbsp;
            <h2>XML read/Write to Server File</h2>
            <p>
                Read and Write to an XML File on the server
            </p>
            <p>
                To Write: &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtXMLData" runat="server" Width="400px">Type something to save</asp:TextBox><br />
                Read Back: <asp:TextBox ID="txtXMLResult" runat="server" Width="400px" Height="155px" TextMode="MultiLine">Data Read back will show here</asp:TextBox><br />
                <br /><asp:Button ID="btnXMLTest" runat="server" Text="Perform XML Validation" OnClick="btnXMLTest_Click" />  
            </p>
        </div>
        <div class="col-md-6">
            <h2>DLL Validation</h2>
            <p>
                This service test the Encrytption DLL for hashing strings
            </p>
            <p>
                Input String: <asp:TextBox ID="txtDllInput" runat="server" Width="400px">String to hash</asp:TextBox><br />
                Hash:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDllResult" runat="server" Width="400px">Hash Results Here</asp:TextBox><br />
                <br /><asp:Button ID="btnTestDll" runat="server" Text="Perform XML Validation" OnClick="btnTestDll_Click"  />  
            </p>
        </div>
    </div>
    <hr style="border: 2px solid red;" />
    <h2>Session Data</h2>
        This data was created in the Session_Start() function in Global.asax<br />
        Session ID:&nbsp; <asp:Label ID="lblSessionID" runat="server" Text="Session ID"></asp:Label><br />
                
        &nbsp;&nbsp;&nbsp;&nbsp;User Name:&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblUser" runat="server" Text="Session User ID"></asp:Label><br />
        &nbsp;&nbsp;&nbsp;&nbsp;Password Hash:&nbsp;<asp:Label ID="lblPasswd" runat="server" Text="Session Password"></asp:Label><br />
        &nbsp;&nbsp;&nbsp;&nbsp;Access Type:&nbsp;&nbsp;&nbsp;  <asp:Label ID="lblAccess" runat="server" Text="Session Password"></asp:Label><br />
</asp:Content>
