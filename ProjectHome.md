**Ever wanted to use Google's great visualizations in your .NET web application?**

Each Google visualization is wrapped in a ASP.NET Web Control.  Add them to your toolbar and drag them into your markup.  Use .NET data tables to populate the chart or graph and now your cooking with gas ... Google.NET gas.

# Announcements! #
*** 09/08/2014 - Now supports Data Visualization Roles
  * 09/08/2014 - Points Added (Star, Diamond, Square, Etc)
  * 02/18/2014 - LineCharts now support Intervals
  * 02/18/2014 - Trendlines now supported for Scatter charts
  * 01/30/2014 - Codebehind creation support.
  * 01/14/2014 - Using GoogleDrive for binaries (.NET 3.5 & 4.0)**

# Home Page Examples #
http://chartsandgraphs.care4soft.com/

# Download Binary(s) #
https://drive.google.com/folderview?id=0B3g23Buye0FHRHlTZ3dMS2VfS1E&usp=sharing


# Quick Start #

  * Reference **GoogleChartsNGraphsControls.dll**
  * Be sure [Visualization](http://code.google.com/p/bortosky-google-visualization) DLL is included in same folder
  * Create a New Tab in Toolbox
  * Click **Add Items**
  * Browse to **GoogleChartsNGraphsControls.dll**
  * Reference the Google JSAPI at the top of your page (Depreciated: No longer have to do this as the controls will register this script for you)
```
<script type='text/javascript' src='http://www.google.com/jsapi'></script>
```


# Building the Project #
  * Download the Source
  * Open the **GoogleChartsNGraphsControls.sln**
  * Build the Project
  * Reference **GoogleChartsNGraphsControls.dll** in Bin\Debug
  * Goto 'Quick Start'

# Javascript Added to your Page #
  * Google.JSAPI - You no longer have to include a reference to google's jsapi.  This will be copied into your project by the control.
```
<script type='text/javascript' src='http://www.google.com/jsapi'></script>
```

  * JX.js - this is a tiny Ajax request api.  It will not interfere with any other AJAX library like Ext, JQuery, or MooTools.  All GoogleCharts come wired automatically for AJAX requests having their data updated.  You can rewire them to a library of your choice.
```
<h3>Gauge Example</h3>
        <cc1:GVGauge ID="GVGauge1" runat="server"  Width="250" Height="150" QueryString="~\AjaxUpdateHandler.ashx?type=gauge"  GviRedFrom="80" GviRedTo="100" GviYellowFrom="50" GviYellowTo="80"/>
        
        <asp:Button ID="ButtonReload" runat="server"  OnClientClick="chart_GVGauge1.reload(); return false;" Text="Ajax Reload" />
```
# Examples #
> (See Google Visualizations for Options and Documentation)

## <font color='#E67451;'>NEW!!</font> AJAX Update Example ##
### Markup ###
```
<h3>Gauge Example</h3>
<cc1:GVGauge ID="GVGauge1" runat="server"  Width="250" Height="150" QueryString="~\AjaxUpdateHandler.ashx?type=gauge"  GviRedFrom="80" GviRedTo="100" GviYellowFrom="50" GviYellowTo="80"/>
        
<asp:Button ID="ButtonReload" runat="server"  OnClientClick="chart_GVGauge1.reload(); return false;" Text="Ajax Reload" />
```
### Code ###
```
public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.AddHeader("Content-Disposition", "inline; filename=Response.json");
            System.Data.DataTable dt = null;
            Random rand = new Random(System.Environment.TickCount);

            switch(context.Request.Params["type"])
            {
                case "column":
                {
                    dt = new System.Data.DataTable("Company Performance");
                    dt.Columns.Add("Year", typeof(string));
                    dt.Columns.Add("Sales", typeof(int));
                    dt.Columns.Add("Expenses", typeof(int));
                    dt.Rows.Add(new object[] { "2004", rand.Next(100, 1000), rand.Next(75,700) });
                    dt.Rows.Add(new object[] { "2005", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2006", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2007", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2008", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2009", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2010", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2011", rand.Next(100, 1000), rand.Next(75, 700) });
                    break;
                }
                default:
                {
                    dt = new System.Data.DataTable("Computer");
                        dt.Columns.AddRange(new System.Data.DataColumn[] {
                        new System.Data.DataColumn("Label",typeof(string)), 
                        new System.Data.DataColumn("Value",typeof(int))
                    });


                    dt.Rows.Add(new object[] { "Memory", rand.Next(0, 100) });
                    dt.Rows.Add(new object[] { "CPU", rand.Next(0, 100) });
                    dt.Rows.Add(new object[] { "Network", rand.Next(0, 100) });
                    break;
                }
        }

            context.Response.Write(new Bortosky.Google.Visualization.GoogleDataTable(dt).GetJson());
        }
```

## Map Example ##
### Markup ###
```
<h3>Map Example</h3>
<cc1:GVMap ID="GVMap2" runat="server" GVIShowTip="True" Height="300px" Width="600px" GVILineColor="Goldenrod" GVILineWidth="4"/>
```
### Code ###
```
this.GVMap2.ChartData("Duvall, WA", "Home Sweet Home");
this.GVMap2.ChartData("Bothell, WA", "Work");
```



## Annotated Timeline Example ##
### Markup ###
```
<h3>Annotated Timeline Example</h3>
<cc1:GVAnnotatedTimeline ID="GVAnnotatedTimeline1" runat="server"  Width="800" Height="400" GVIDisplayAnnotations="True" GviDisplayDateBarSeparator="true" GviAllowRedraw="true"/>
```
### Code ###
```
List<GoogleChartsNGraphsControls.TimelineEvent> evts = new List<GoogleChartsNGraphsControls.TimelineEvent>();
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008,1,1), 30000));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 2), 14045));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 3), 55022));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 4), 75284));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 5), 41476));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 6), 33322));

evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pens", new DateTime(2008, 1, 1), 40645));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pens", new DateTime(2008, 1, 2), 20374));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pens", new DateTime(2008, 1, 3), 50766));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pens", new DateTime(2008, 1, 4), 14334, "Out of Stock", "Ran out of stock on pens at 4pm"));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pens", new DateTime(2008, 1, 5), 66467, "Bought Pens", "Bought 200k pens"));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pens", new DateTime(2008, 1, 6), 39463));

evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Erasers", new DateTime(2008, 1, 1), 0, "No Erasers", "What was i thinking?"));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Erasers", new DateTime(2008, 1, 2), 1254, "Bought Erasers", "Bought 200k erasers for all the mistakes"));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Erasers", new DateTime(2008, 1, 3), 4596));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Erasers", new DateTime(2008, 1, 4), 14334));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Erasers", new DateTime(2008, 1, 5), 26004));
evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Erasers", new DateTime(2008, 1, 6), 39001));
this.GVAnnotatedTimeline1.ChartData(evts.ToArray());
```



## Pie Chart Example ##
### Markup ###
```
<h3>PieChart Example</h3>
<cc1:GVPieChart ID="GVPieChart1" runat="server" Width="600" Height="400" />
```
### Code ###
```
System.Data.DataTable dt = new System.Data.DataTable("Work Day");
dt.Columns.Add("Activity");
dt.Columns.Add("Daily Percentage", typeof(int));
dt.Rows.Add(new object[] {"Engineering",5});
dt.Rows.Add(new object[] { "Programming", 3 });
dt.Rows.Add(new object[] { "Sleeping", 1 });
dt.Rows.Add(new object[] { "Lunch", 1 });
dt.Rows.Add(new object[] { "Meetings", 1 });
this.GVPieChart1.ChartData(dt);
```


> ... And Many More ...