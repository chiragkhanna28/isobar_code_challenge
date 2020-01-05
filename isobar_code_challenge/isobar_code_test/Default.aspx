<%@ Page Title="Isobar Code Test" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="isobar_code_test._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Isobar Code Test</title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <div class="container">
        <form id="Form1" runat="server">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="heading-section">
                        <asp:Label ID="Heading" runat="server" Text="Get 5 closest locations near you" CssClass="heading"></asp:Label>
                    </div>
                    <div class="section input-section">
                        <asp:Label ID="AddressLabel" runat="server" Text="Please enter the address"></asp:Label>
                        <asp:TextBox ID="Address" runat="server" CssClass="Address"></asp:TextBox>
                        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
                    </div>
                    <div class="section output-section">
                        <asp:PlaceHolder ID="DynamicDataPlaceHolder" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="section error-section">
                        <asp:Label ID="ErrorMessage" runat="server" Text="Sorry we are unable to process you request" CssClass="error-message" Visible="false"></asp:Label>
                    </div>
                </div>
    </div>
    </form>
    </div>
</body>
</html>
