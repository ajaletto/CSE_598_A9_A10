<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aletto_A9_TryIt.aspx.cs" Inherits="Aletto_Doyal_A9_A10.Aletto_A9_TryIt" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<botdetect xmlns="https://captcha.com/schema/net" 
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xsi:schemaLocation="https://captcha.com/schema/net 
      https://captcha.com/schema/net/botdetect-4.4.0.xsd">
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
        <div class="col">
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
                <fieldset>
                  <legend>ASP.NET WebForm CAPTCHA Validation</legend>
                  <p class="prompt">
                    <label for="CaptchaCodeTextBox">Retype the characters from the picture:</label><br />
                    <BotDetect:WebFormsSimpleCaptcha runat="server" ID="ExampleCaptcha"/>
                  <div class="validationDiv">
                    <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
                    <asp:Button ID="ValidateCaptchaButton" Text="Validate" runat="server" OnClick="ValidateCaptchaButton_Click" />
                    <br />
                    <asp:Label ID="CaptchaCorrectLabel" runat="server" style="font-size: medium"></asp:Label>
                    <asp:Label ID="CaptchaIncorrectLabel" runat="server" style="font-size: medium; color: #FF0000"></asp:Label>
                  </div>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
