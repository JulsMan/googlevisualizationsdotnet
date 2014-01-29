<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Codebehind.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.Codebehind" %>

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
        <h3>Markup</h3>
        <cc1:GVGauge ID="GVGauge1" runat="server" Width="200" Height="100" />
        <p />

         <h3>Codebehind</h3>
         <div>
            <asp:PlaceHolder ID="PlaceHolderChart" runat="server" />
         </div>
    </div>
    </form>
</body>
</html>
