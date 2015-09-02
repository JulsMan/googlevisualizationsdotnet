<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CHAP.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.CHAP" %>
<%@ Register assembly="GoogleChartsNGraphsControls" namespace="GoogleChartsNGraphsControls" tagprefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    </style>
    <script type="text/javascript">
        function onSelection(chart) {
            if (chart != undefined && chart.getSelection() != undefined) {
                alert(chart.getSelection()[0].row);
            }
        }

        function onChangeOfRange(chart) {
            if (chart != undefined)
            {
                var newRange = chart.getVisibleChartRange();
                alert("From " + newRange.start +" to "+newRange.end)
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h3>CHAP Timeline implementation</h3>
        <cc1:CHAPTimeline ID="CHAPTimeline1" runat="server"  Width="900" Height="220"  GviOnSelect="onSelection" GviOnRangeChanged="onChangeOfRange"  />
    </form>
</body>
</html>
