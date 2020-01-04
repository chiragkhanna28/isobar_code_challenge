<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="isobar_code_test._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <div class="container">
        <form id="Form1" runat="server">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:Label ID="AddressLabel" runat="server" Text="Please enter the address"></asp:Label>
                    <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />


                    <asp:PlaceHolder ID="DynamicDataPlaceHolder" runat="server"></asp:PlaceHolder>


                </div>
            </div>
        </form>
    </div>
</body>
</html>
