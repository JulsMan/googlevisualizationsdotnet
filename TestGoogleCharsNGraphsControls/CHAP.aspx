<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CHAP.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.CHAP" %>
<%@ Register assembly="GoogleChartsNGraphsControls" namespace="GoogleChartsNGraphsControls" tagprefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3>CHAP Timeline implementation</h3>
        <cc1:CHAPTimeline ID="CHAPTimeline1" runat="server"  Width="900" Height="220" />
    </form>
</body>
</html>
