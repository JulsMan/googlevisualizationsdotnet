<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="debug.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.debug" %>
<%@ Register assembly="GoogleChartsNGraphsControls" namespace="GoogleChartsNGraphsControls" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <asp:PlaceHolder ID="PlaceHolderChart" runat="server" />


        <cc1:GVLineChart ID="GVLineChart1" runat="server" Width="600" Height="400"  GviColorsByName="Red Green Blue Orange" />


    </form>
</body>
</html>
