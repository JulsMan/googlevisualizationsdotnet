<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntervalNTrend.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.sandbox" %>

<%@ Register Assembly="GoogleChartsNGraphsControls" Namespace="GoogleChartsNGraphsControls"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intervals and Trendlines</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


      <h3>Scatter Chart with Trendline</h3>
        <cc1:GVScatterChart ID="GVScatterChart1" runat="server"  Width="500" Height="400"/>

    </div>


     <h3>Line Chart with Intervals</h3>
        <cc1:GVLineChart ID="GVLineChart1" runat="server" Width="500" Height="400" GviCurveType="Function" />

    </div>

    </form>
</body>
</html>
