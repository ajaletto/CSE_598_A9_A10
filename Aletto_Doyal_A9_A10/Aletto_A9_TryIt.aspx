<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aletto_A9_TryIt.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Aletto_A9_TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Anthony Aletto Assignment 9 TryIt Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: 100px; font-weight: bolder; color: #000080">
            <p>
                Anthony Aletto Assignment 9 TryIt Page
            </p>
        </div>
        <div class="row">
            <div style="font-size: medium" class="col-md-6">
                <p style="font-size: x-large; font-weight: bold">Cookies Try It</p>
                <asp:Label ID="lblCookieTryit" runat="server" Text="Label" Width="500px"></asp:Label><br />
                <asp:TextBox ID="txtbxCookieTryitInput" runat="server"></asp:TextBox>&nbsp;
                <p style="color: #FF0000">
                    <asp:Label ID="lblCookieTryItWarning" runat="server" Text=""></asp:Label>
                </p>

                <br />
                <asp:Button ID="btnCookieTryitAdd" runat="server" Text="Add" OnClick="btnCookieTryitAdd_Click" />
                <br />
                <br />
                <asp:Button ID="btnCookieTryitDelete" runat="server" Text="Delete" OnClick="btnCookieTryitDelete_Click" />
            
            </div>
            <hr />
            <div style="font-size: medium" class="col-md-6">
            </div>
        </div>
    </form>
</body>
</html>
