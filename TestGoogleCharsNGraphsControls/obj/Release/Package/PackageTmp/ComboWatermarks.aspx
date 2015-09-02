<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComboWatermarks.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.ComboWatermarks" %>
<%@ Register assembly="GoogleChartsNGraphsControls" namespace="GoogleChartsNGraphsControls" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  
         <h3>ComboChart</h3>

        <cc1:GVComboChart ID="GVComboChart1" runat="server"  Width="680" Height="400" GviAnimation_Duration="1000" GviAnimation_Easing="Out"/>

    </form>
</body>
</html>
