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
    


      <h3>Scatter Chart with Trendline</h3>
        <cc1:GVScatterChart ID="GVScatterChart1" runat="server"  Width="500" Height="400"/>

    <pre style="background-color:InfoBackground">
          GoogleChartsNGraphsControls.TrendLine trend = new GoogleChartsNGraphsControls.TrendLine()
            {
                Color = Color.MediumPurple,
                Opacity = 0.4f,
                LineWidth = 10,
                VisibleInLegend = true,
                LabelInLegend = "Trend Line",
                Type = GoogleChartsNGraphsControls.TrendLineType.Exponential
            };

            this.GVScatterChart1.GviTrendLine = new GoogleChartsNGraphsControls.TrendLine[] { trend };
    </pre>


     <h3>Line Chart with Intervals</h3>
        <cc1:GVLineChart ID="GVLineChart1" runat="server" Width="500" Height="400" GviCurveType="Function" />
    
     <pre style="background-color: InfoBackground">
         this.GVLineChart1.GviIntervals = new GoogleChartsNGraphsControls.Interval[] 
            {
                    new GoogleChartsNGraphsControls.Interval() { BarWidth = 3, Color = System.Drawing.Color.MediumPurple, Opacity = 0.2f, 
                   Style = GoogleChartsNGraphsControls.IntervalStyle.Area   },
                    new GoogleChartsNGraphsControls.Interval() { BarWidth = 1, Color = System.Drawing.Color.IndianRed, Opacity = 0.2f, 
                   Style = GoogleChartsNGraphsControls.IntervalStyle.Box   },
                   new GoogleChartsNGraphsControls.Interval() { BarWidth = 3, Color = System.Drawing.Color.IndianRed, Opacity = 0.2f, 
                   Style = GoogleChartsNGraphsControls.IntervalStyle.Area   },
                    new GoogleChartsNGraphsControls.Interval() { BarWidth = 1, Color = System.Drawing.Color.LightBlue, Opacity = 0.2f, 
                   Style = GoogleChartsNGraphsControls.IntervalStyle.Box   },
            };
    </pre>

    </form>
</body>
</html>
