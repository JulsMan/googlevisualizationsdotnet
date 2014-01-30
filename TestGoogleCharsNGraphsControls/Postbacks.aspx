<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Postbacks.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.Postbacks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Charts with Postback Annimation</h3>

        <asp:PlaceHolder ID="PlaceHolderChart" runat="server" />

        <p />

        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click" PostBackUrl="~/Postbacks.aspx" />
    </div>
    </form>
</body>
</html>
