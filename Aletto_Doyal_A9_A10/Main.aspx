<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Main.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Main" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <title>Aletto and Doyal's Alternative Gas Station Lookup Service</title>
    </head>
    <h1 class="col-lg-12" style="border: 8px ridge #000000; font-family: Bahnschrift; font-size: 75px; font-weight: bolder; color: #00004D; background-color: #13EC80; display: block; text-align: center; " aria-haspopup="False" role="banner">Aletto and Doyal's Alternative Gas Station Lookup Services
        <asp:Button ID="btnServiceDirectory" runat="server" Text="Service Directory" Font-Size="XX-Large" CssClass="center-block" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" Font-Bold="True" Height="100px" OnClick="btnServiceDirectory_Click" />
        <br />
    </h1>
    <hr />
    <body style="background-color: #FFFFFF; background-image: url('App_Images/Road.jpg'); ">        
               
        <div class="row">

            <div class="col-lg-6" style="border: 5px solid #C0C0C0; background-color: #1879BA; color: #FFFFFF;">
                <h2 style="border: 7px solid #000000; font-size: 40px; background-color: #808080; text-align: center; color: #000000; font-weight: bold;">Find Alternative Fuel Stations By Location</h2>
                <p style="font-size: medium; text-align: center;">
                    <asp:Label ID="lblAddressLocation" runat="server" Text="Address:" BorderColor="Black"></asp:Label><br />
                    <asp:TextBox ID="txtbxAddressLocationInput" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblCityLocation" runat="server" Text="City:"></asp:Label><br />
                    <asp:TextBox ID="txtbxCityLocationInput" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblStateLocation" runat="server" Text="State:"></asp:Label><br />
                    <asp:DropDownList ID="drpdnStateLocation" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="name" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black">
                    </asp:DropDownList>
                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/states.xml"></asp:XmlDataSource>
                    <br />
                    <br />
                    <asp:Label ID="lblZipcodeLocation" runat="server" Text="Zipcode:"></asp:Label><br />
                    <asp:TextBox ID="txtbxZipcodeLocation" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblRadiusLocation" runat="server" Text="Radius in Miles:"></asp:Label><br />
                    <asp:TextBox ID="txtbxRadiusLocation" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnGetAltFuelAtLocation" runat="server" Text="Get Fuel Stations" ForeColor="Black" OnClick="btnGetAltFuelAtLocation_Click" BorderStyle="Solid" BorderColor="Black" BorderWidth="5" Font-Bold="True" Font-Size="16" />
                </p>
            </div>
            <div class="col-lg-6" style="margin: 0px; border: 5px solid #C0C0C0; background-color: #1879BA; color: #FFFFFF; overflow: visible;">
                <h2 style="border: 7px solid #000000; font-size: 40px; background-color: #808080; text-align: center; font-weight: bold;">Location
                    <br />
                    Output</h2>
                <p style="font-size: medium; text-align: center;">

                    <textarea runat="server" class="container-fluid" id="txtarLocationOutput" cols="100" name="S1" rows="2" style="margin: 0px; text-align: left; min-width: 95%; height: 429px; color: #000000; font-size: large;"></textarea>

                </p>
            </div>


            <hr />
            <div class="col-lg-6" style="border: 5px solid #C0C0C0; background-color: #008080; text-align: center;">
                <h2 style="border: 7px inset #000000; font-size: 40px; background-color: #808080; font-weight: bold; color: #000000; text-align: center;">Find Alternative Fuel Stations Along a Route</h2>
                <div class="col-md-3" style="color: #FFFFFF; text-align: center;">
                    <h3 style="font-size: 32px; font-weight: bold; text-decoration: underline; text-align: center;">From:</h3>
                    <p style="font-size: medium; min-width: 100%;">
                        <asp:Label ID="lblFromAddressRoute" runat="server" Text="Address:"></asp:Label>
                        <asp:TextBox ID="txtbxFromAddressRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblFromCityRoute" runat="server" Text="City:"></asp:Label><br />
                        <asp:TextBox ID="txtbxFromCityRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblFromStateRoute" runat="server" Text="State:"></asp:Label>
                        <asp:DropDownList ID="drpdnFromStateRoute" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="name" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300">
                        </asp:DropDownList>
                        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/states.xml"></asp:XmlDataSource>
                        <br />
                        <br />
                        <asp:Label ID="lblFromZipcodeRoute" runat="server" Text="Zipcode:"></asp:Label>
                        <asp:TextBox ID="txtbxFromZipcodeRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                        <br />
                    </p>
                </div>



                <div class="col-md-3 col-md-offset-3" style="color: #FFFFFF; text-align: center;">
                    <h3 style="font-size: 32px; font-weight: bold; text-decoration: underline; text-align: center;">To:</h3>
                    <p style="font-size: medium; min-width: 100%;">
                        <asp:Label ID="lblToAddressRoute" runat="server" Text="Address:"></asp:Label>
                        <asp:TextBox ID="txtbxToAddressRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblToCityRoute" runat="server" Text="City:"></asp:Label><br />
                        <asp:TextBox ID="txtbxToCityRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblToStateRoute" runat="server" Text="State:"></asp:Label>
                        <asp:DropDownList ID="drpdnToStateRoute" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="name" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300">
                        </asp:DropDownList>
                        <asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile="~/App_Data/states.xml"></asp:XmlDataSource>
                        <br />
                        <br />
                        <asp:Label ID="lblToZipcodeRoute" runat="server" Text="Zipcode:"></asp:Label>
                        <asp:TextBox ID="txtbxToZipcodeRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                        <br />
                        <br />
                    </p>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <p style="font-size: medium; text-align: center;">
                    <asp:Label ID="lblIntervalRoute" runat="server" Text="Interval Between Stations:" ForeColor="White"></asp:Label><br />
                    <asp:TextBox ID="txtbxIntervalRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black" Width="300"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnGetAltFuelStationsAlongRoute" runat="server" Text="Get Fuel Stations Along Route" BorderColor="Black" BorderStyle="Solid" BorderWidth="5" Font-Bold="True" OnClick="btnGetAltFuelStationsAlongRoute_Click" />
                </p>
            </div>
            <div class="col-lg-6" style="margin: 0px; border: 5px solid #C0C0C0; background-color: #008080; color: #FFFFFF; overflow: visible;">
                <h2 style="border: 7px solid #000000; font-size: 40px; background-color: #808080; text-align: center; font-weight: bold;">Routing Info
                    <br />
                    Output</h2>
                <p style="font-size: medium; text-align: center;">

                    <textarea runat="server" class="container-fluid" id="txtarRouteOutput" cols="100" name="S1" rows="2" style="margin: 0px; text-align: left; min-width: 95%; height: 508px; color: #000000; font-size: large;"></textarea>

                </p>
            </div>
            <div class="col-lg-12" style="text-align: center; font-size: xx-large;">
                <br />
                <asp:Button ID="exit" runat="server" Text="Exit" BorderColor="Black" BorderStyle="Solid" BorderWidth="5" Font-Bold="True" Height="100" OnClick="exit_Click" />
            </div>
        </div>
    </body>

</asp:Content>
