<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaUserControl.ascx.cs" Inherits="Aletto_Doyal_A9_A10.CaptchaUserControl" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>

<botdetect xmlns="https://captcha.com/schema/net" 
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xsi:schemaLocation="https://captcha.com/schema/net 
      https://captcha.com/schema/net/botdetect-4.4.0.xsd">

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
