<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sandbox.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.sandbox" %>

<%@ Register Assembly="GoogleChartsNGraphsControls" Namespace="GoogleChartsNGraphsControls"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:GVAnnotatedTimeline ID="GVAnnotatedTimeline1" runat="server"  GviDisplayZoomButtons="False" Width="900" Height="500" />


    </div>
    </form>
</body>
</html>
