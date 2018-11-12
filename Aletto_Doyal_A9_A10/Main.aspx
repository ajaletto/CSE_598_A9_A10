<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Main.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Main" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <title>Aletto and Doyal's Alternative Gas Station Lookup Service</title>
    </head>
    <h1 class="col-lg-12" style="border: 8px ridge #000000; font-family: Bahnschrift; font-size: 75px; font-weight: bolder; color: #00004D; background-color: #C0C0C0; display: block;" aria-haspopup="False" role="banner">
        Aletto and Doyal's Alternative Gas Station Lookup Services
    </h1>
    <hr />
    <body>        
            <div class="row">

                <div class="col-lg-5" style="border: 5px solid #C0C0C0; background-color: #1879BA; color: #FFFFFF;">
                    <h2 style="border: 7px solid #000000; font-size: 40px; background-color: #808080; font-weight: bold; color: #000000;">Find Alternative Fuel Stations By Location</h2>
                    <p style="font-size: medium">
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
                        <asp:Button ID="btnGetAltFuelAtLocation" runat="server" Text="Get Alt Fuel Stations Near Location" ForeColor="Black" />
                    </p>
                </div>
                


                <hr />
                <div class="col-lg-7" style="border: 5px solid #C0C0C0; background-color: #008080;">
                    <h2 style="border: 7px inset #000000; font-size: 40px; background-color: #808080; font-weight: bold; color: #000000; text-align: center;">Find Alternative Fuel Stations Along a Route</h2>



                    <div class="col-md-3" style="color: #FFFFFF">
                        <h3 style="font-size: 32px; font-weight: bold; text-decoration: underline;">From:</h3>
                        <p style="font-size: medium">
                            <asp:Label ID="lblFromAddressRoute" runat="server" Text="Address:"></asp:Label>
                            <asp:TextBox ID="txtbxFromAddressRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>                            
                            <br />
                            <br />
                            <asp:Label ID="lblFromCityRoute" runat="server" Text="City:"></asp:Label>
                            <asp:TextBox ID="txtbxFromCityRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>                            
                            <br />
                            <br />
                            <asp:Label ID="lblFromStateRoute" runat="server" Text="State:"></asp:Label>
                            <asp:DropDownList ID="drpdnFromStateRoute" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="name" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/states.xml"></asp:XmlDataSource>                            
                            <br />
                            <br />
                            <asp:Label ID="lblFromZipcodeRoute" runat="server" Text="Zipcode:"></asp:Label>
                            <asp:TextBox ID="txtbxFromZipcodeRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>                            
                            <br />
                        </p>
                    </div>



                    <div class="col-md-4 col-md-offset-4" style="color: #FFFFFF">
                        <h3 style="font-size: 32px; font-weight: bold; text-decoration: underline;">To:</h3>
                        <p style="font-size: medium">
                            <asp:Label ID="lblToAddressRoute" runat="server" Text="Address:"></asp:Label>
                            <asp:TextBox ID="txtbxToAddressRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>                            
                            <br />
                            <br />
                            <asp:Label ID="lblToCityRoute" runat="server" Text="City:"></asp:Label>
                            <asp:TextBox ID="txtbxToCityRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="lblToStateRoute" runat="server" Text="State:"></asp:Label>
                            <asp:DropDownList ID="drpdnToStateRoute" runat="server" DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="name" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile="~/App_Data/states.xml"></asp:XmlDataSource>
                            <br />
                            <br />
                            <asp:Label ID="lblToZipcodeRoute" runat="server" Text="Zipcode:"></asp:Label>
                            <asp:TextBox ID="txtbxToZipcodeRoute" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" ForeColor="Black"></asp:TextBox>
                            <br />
                            <br />
                        </p>
                    </div>
                    <div class="col-md-3 col-md-offset-3">
                        <p style="font-size: medium">
                            <asp:Button ID="btnGetAltFuelStationsAlongRoute" runat="server" Text="Get Alt Fuel Stations Along Route" />
                        </p>
                    </div>
                </div>
                <br />
                
            </div>
        <div class="col-lg-12">
            <br />
            <asp:Button ID="btnServiceDirectory" runat="server" Text="Service Directory" Font-Size="XX-Large" minWidth="2000px" CssClass="center-block" Width="1500px" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" Font-Bold="True" Font-Overline="False" Height="100px" />
        </div>
    </body>

</asp:Content>
