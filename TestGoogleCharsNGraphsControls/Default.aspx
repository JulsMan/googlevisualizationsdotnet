 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableViewState="false" Inherits="TestGoogleCharsNGraphsControls.WebForm1" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="GoogleChartsNGraphsControls" namespace="GoogleChartsNGraphsControls" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>C# Examples </title>
    <style>
        .sloppyCode
        {
            background-color: #FAF8CC; 
            border: dashed 1px grey; 
            text-align: left; 
            margin-left: 55px;
            padding: 16px 0px 0px 16px;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"> </script>
    <script src="Events.Examples.js" type="text/javascript"></script>
    <script type="text/javascript">
        var reloadCharts = function(){
            for (var key in this) {
                if (key.indexOf('chart_GV') > -1) {
                    eval(key + ".reload();");
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        


        <pre>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
        </pre>
        <span style="color:Orange">Very New!!</span> <a href="intervalNTrend.aspx">Interval & Trendlines</a>
          <br />
         <span style="color:Orange">New!!</span> <a href="Codebehind.aspx">Goto Codebehind Examples</a>
          <br />
         <span style="color:Orange">New!!</span> <a href="Postbacks.aspx">Goto Codebehind with Postbacks</a>
           <br />
        <a href="GeoMaps.aspx">More Maps</a><cc1:GVMap ID="GVMap2" runat="server" GVIShowTip="True" Height="300px" 
            Width="600px" GVILineColor="Goldenrod" GVILineWidth="4" GviShowLine="true"/>
        <br />

        <h3>Map ExamplMap Example</h3>
        
            <pre class="sloppyCode">
                Sample Code:
                this.GVMap2.ChartData("Duvall, WA", "Home Sweet Home");
                this.GVMap2.ChartData("Bothell, WA", "Work");
            </pre>
        <p />
        
     
        
        <p />
        <h3>Annotated Timeline Example     <script type="text/javascript">
       
        </script>
        <cc1:GVAnnotatedTimeline ID="GVAnnotatedTimeline1" runat="server"  Width="800" Height="400" 
        GVIDisplayAnnotations="True" GviDisplayDateBarSeparator="True" GviAllowRedraw="True" GviHighlightDot="Last" GviTitle="Get Options to Show" 
        GviOptionsOverride="{displayAnnotations:false}" OnEvent_GviSelect="MyTimeLineSelectHandler" OnEvent_GviRangeChange="MyTimeLineRangeChange"/>
        <pre class="sloppyCode">
                Sample Code:
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

            </pre>
            
        <p />
        <h3>Annotated Timeline Example</h3>
        <cc1:GVAnnotatedTimeline ID="GVAnnotatedTimeline2" runat="server" Width="800" Height="400" GVIDisplayAnnotations="True"  />
        <pre class="sloppyCode">
                Sample Code:
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
                this.GVAnnotatedTimeline2.ChartData(evts.Where(d => d.EventCategory == "Sold Erasers").ToArray());
            </pre>
            


        <p />
         <h3>Annotation Example</h3>
            <cc1:GVAnnotationChart ID="GVAnnotationChart1" runat="server" Width="800" Height="400"/>
        


          <p />
         <h3>Calendar Example</h3>
            <cc1:GVCalendar ID="GVCalendar1" runat="server"  Width="600" Height="400"/>


        <p />
        <span style="color:#FFA500">New</span>!!!  &nbsp; <h3>CandleStick Example</h3>
        A candlestick chart is used to show an opening and closing value overlaid on top of a total variance.,<br/> 
        Candlestick charts are often used to show stock value behavior. <br/> 
        In this chart, items where the opening value is less than the closing value (a gain) are drawn as filled boxes, <br/> 
        and items where the opening value is more than the closing value (a loss) are drawn as hollow boxes.<br/> 
        
        <cc1:GVCandlestickChart ID="GVCandlestickChart1" runat="server" Width="600" Height="400" GviAnimation_Duration="1000" GviAnimation_Easing="Out" />
        <pre class="sloppyCode">
        Sample Code:
        System.Data.DataTable candlestick = new System.Data.DataTable("Stock");
            candlestick.Columns.AddRange(new System.Data.DataColumn[]{
                    new System.Data.DataColumn("DayOfWeek", typeof(String)),
                    new System.Data.DataColumn("Morning", typeof(int)),
                    new System.Data.DataColumn("Afternoon", typeof(int)),
                    new System.Data.DataColumn("Evening", typeof(int)),
                    new System.Data.DataColumn("Night", typeof(int))
                });
            candlestick.Rows.Add(new object[] { "Mon", 20, 28, 38, 45 });
            candlestick.Rows.Add(new object[] { "Tues", 31, 38, 55, 66 });
            candlestick.Rows.Add(new object[] { "Wed", 50, 55, 77, 80});
            candlestick.Rows.Add(new object[] { "Thurs", 50, 77, 66, 77});
            candlestick.Rows.Add(new object[] { "Fri", 15, 66, 22, 68});

            this.GVCandlestickChart1.GviTitle = "Stock Value over Week";
            this.GVCandlestickChart1.DataSource = candlestick;
            this.GVCandlestickChart1.DataBind();
        </pre>




        <p />
        <h3>PieChart Example</h3>
        <cc1:GVPieChart ID="GVPieChart1" runat="server" Width="600" Height="400" />
        
        With Postback: <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="Sun" />
            <asp:ListItem Text="Mon" />
            <asp:ListItem Text="Tues" />
            <asp:ListItem Text="Wed" />
            <asp:ListItem Text="Thur" />
            <asp:ListItem Text="Fri" />
            <asp:ListItem Text="Sat" />
        </asp:DropDownList>
        
        <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable dt = new System.Data.DataTable("Work Day");
            dt.Columns.Add("Activity");
            dt.Columns.Add("Daily Percentage", typeof(int));
            dt.Rows.Add(new object[] {"Engineering",5});
            dt.Rows.Add(new object[] { "Programming", 3 });
            dt.Rows.Add(new object[] { "Sleeping", 1 });
            dt.Rows.Add(new object[] { "Lunch", 1 });
            dt.Rows.Add(new object[] { "Meetings", 1 });

            this.GVPieChart1.ChartData(dt);
        </pre>


        <h3>Donut Example</h3>
        <cc1:GVDonutChart ID="GVDonutChart1" runat="server" Width="600" Height="400" />
        
       
        
        <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable dt = new System.Data.DataTable("Work Day");
            dt.Columns.Add("Activity");
            dt.Columns.Add("Daily Percentage", typeof(int));
            dt.Rows.Add(new object[] {"Engineering",5});
            dt.Rows.Add(new object[] { "Programming", 3 });
            dt.Rows.Add(new object[] { "Sleeping", 1 });
            dt.Rows.Add(new object[] { "Lunch", 1 });
            dt.Rows.Add(new object[] { "Meetings", 1 });

            this.GVDonutChart1.ChartData(dt);
        </pre>
        
        
        
        <p />
        <h3>PieChart Example</h3>
        <cc1:GVPieChart ID="GVPieChart2" runat="server" Width="600" Height="400" GviTitle="Favorite Pets" 
         QueryString="~/AjaxUpdateHandler.ashx?type=GVPieChart2" GviIs3D="true" />
        
        With AJAX Handler: <select id="Select1" onchange="chart_GVPieChart2.reload( Select1.options[Select1.selectedIndex].value )">
            <option>Sun</option>
            <option>Mon</option>
            <option>Tues</option>
            <option>Wed</option>
            <option>Thurs</option>
            <option>Fri</option>
            <option>Sun</option>
        </select>
         
        
         <pre class="sloppyCode">
            Sample Code:
             System.Data.DataTable dt = new System.Data.DataTable("Work Day");
            dt.Columns.Add("Activity");
            dt.Columns.Add("Daily Percentage", typeof(int));
            dt.Rows.Add(new object[] {"Engineering",5});
            dt.Rows.Add(new object[] { "Programming", 3 });
            dt.Rows.Add(new object[] { "Sleeping", 1 });
            dt.Rows.Add(new object[] { "Lunch", 1 });
            dt.Rows.Add(new object[] { "Meetings", 1 });
            
            this.GVPieChart2.GviTitle = "Where I Spend My Time";
            this.GVPieChart2.GviLegend = "left";
            this.GVPieChart2.GviIs3D = true;
            this.GVPieChart2.ChartData(dt);
        </pre>
        
        
        <p />
        
        
         <p />
        <h3>AreaChart Example</h3>
        <cc1:GVAreaChart ID="GVAreaChart2" runat="server" Width="600" Height="400" 
        GviColorsByName="Red Green Blue Orange" OnEvent_GviSelect="MyAreaChartSelectHandler" OnEvent_GviOnMouseOver="MyAreaChartMouseOverHandler" />
        
        <div id="AreaShowMouseOver">
            Mouse Over to Become Active
        </div>
        
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable dt2 = new System.Data.DataTable("Company Sales/Expenses");
            dt2.Columns.Add("Year");
            dt2.Columns.Add("Expenses", typeof(int));
            dt2.Columns.Add("Sales", typeof(int));
            dt2.Rows.Add(new object[] { "2004", 215000, 225000});
            dt2.Rows.Add(new object[] { "2005", 300000, 320000});
            dt2.Rows.Add(new object[] { "2006", 326000, 356000});
            dt2.Rows.Add(new object[] { "2007", 485000, 490000});
            dt2.Rows.Add(new object[] { "2008", 410000, 442000 });
            dt2.Rows.Add(new object[] { "2009", 466000, 422000 });
            dt2.Rows.Add(new object[] { "2010", 480000, 435000});
            this.GVAreaChart2.ChartData(dt2);
        </pre>
        
        
        <p />
        <h3>LineChart Example</h3>
        <cc1:GVLineChart ID="GVLineChart1" runat="server" Width="600" Height="400" 
            GviColorsByName="Red Green Blue Orange">
        </cc1:GVLineChart>
        
        
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable dt2 = new System.Data.DataTable("Company Sales/Expenses");
            dt2.Columns.Add("Year");
            dt2.Columns.Add("Expenses", typeof(int));
            dt2.Columns.Add("Sales", typeof(int));
            dt2.Rows.Add(new object[] { "2004", 215000, 225000});
            dt2.Rows.Add(new object[] { "2005", 300000, 320000});
            dt2.Rows.Add(new object[] { "2006", 326000, 356000});
            dt2.Rows.Add(new object[] { "2007", 485000, 490000});
            dt2.Rows.Add(new object[] { "2008", 410000, 442000 });
            dt2.Rows.Add(new object[] { "2009", 466000, 422000 });
            dt2.Rows.Add(new object[] { "2010", 480000, 435000});
            this.GVLineChart1.ChartData(dt2);
        </pre>
        
        
        <p />
        <h3>LineChart Stackable Example</h3>
        <cc1:GVLineChart ID="GVLineChart22" runat="server" Width="600" Height="400"
            GviColorsByName="Red Green Blue Orange">
        </cc1:GVLineChart>
        
        
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable dt2 = new System.Data.DataTable("Company Sales/Expenses");
            dt2.Columns.Add("Year");
            dt2.Columns.Add("Expenses", typeof(int));
            dt2.Columns.Add("Sales", typeof(int));
            dt2.Rows.Add(new object[] { "2004", 215000, 225000});
            dt2.Rows.Add(new object[] { "2005", 300000, 320000});
            dt2.Rows.Add(new object[] { "2006", 326000, 356000});
            dt2.Rows.Add(new object[] { "2007", 485000, 490000});
            dt2.Rows.Add(new object[] { "2008", 410000, 442000 });
            dt2.Rows.Add(new object[] { "2009", 466000, 422000 });
            dt2.Rows.Add(new object[] { "2010", 480000, 435000});

            this.GVLineChart22.ChartData(dt2);
        </pre>


        
        <p />
        <h3>BarChart Example</h3>
        <cc1:GVBarChart ID="GVBarChart1" runat="server" Width="600" Height="400"  OnClick="GVBarChart1_Click" />
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            this.GVBarChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            this.GVBarChart1.ChartData(barchart);
        </pre>


         <p />
        <h3>BarChart Stacked Example</h3>
        <cc1:GVBarChart ID="GVBarChartStacked" runat="server" Width="600" Height="400"  OnClick="GVBarChart1_Click" GviIsStacked="true" />
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            this.GVBarChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            this.GVBarChart1.ChartData(barchart);
        </pre>



        <p />
        <h3>BarChart With Events Example</h3>
        <cc1:GVBarChart ID="GVBarChartEvents" runat="server" Width="600" Height="400" GviOnError="fnOnError" 
        GviOnMouseout="fnOnOut" GviOnMouseover="fnOnOver" GviOnReady="fnOnReady" GviOnSelect="fnOnSelect"  />
        
         <script type="text/javascript" language="javascript">
             function fnOnError(id, msg) {
                 try {
                     alert(chart_GVBarChartEvents.container.id + ' Error: ' + id + ' - ' + msg);
                 }
                 catch (err) {
                 }
             }
             function fnOnOut(evt) {
                 window.console && console.log(chart_GVBarChartEvents.container.id + ' mouse out at ' + evt.row + ':' + evt.column);
             }
             function fnOnOver(evt) {
                 window.console && console.log(chart_GVBarChartEvents.container.id + ' mouse over at ' + evt.row + ':' + evt.column);
             }
             function fnOnReady() {
                 window.console && console.log(chart_GVBarChartEvents.container.id + ' is ready!');
             }
             function fnOnSelect() {
                 try {
                     var chart = chart_GVBarChartEvents;
                     var sel = chart.getSelection();
                     var dt = chart.getData();
                     alert('You selected col[' + sel[0].column + '], row[' + sel[0].row + ']' +
                    '\nData: ' + dt.getColumnLabel(sel[0].column) + ' was ' + dt.getValue(sel[0].row, sel[0].column)
                    + ' for ' + dt.getValue(sel[0].row, 0));
                 }
                 catch (err) {
                     alert('Oops!  OnSelect Error = ' + err);
                 }
             }
        </script> 
         
         <pre class="sloppyCode">

             &lt;cc1:GVBarChart ID=&quot;GVBarChart3&quot; runat=&quot;server&quot; Width=&quot;600&quot; Height=&quot;400&quot; GviOnError=&quot;fnOnError&quot; GviOnMouseout=&quot;fnOnOut&quot; GviOnMouseover=&quot;fnOnOver&quot; GviOnReady=&quot;fnOnReady&quot; GviOnSelect=&quot;fnOnSelect&quot;  /&gt;

           &lt;script type=&quot;text/javascript&quot; language=&quot;javascript&quot;&gt;
            function fnOnError(id, msg) {
                try {
                    alert(chart_GVBarChartEvents.container.id + ' Error: ' + id + ' - ' + msg);
                }
                catch (err) {
                }
            }
            function fnOnOut(evt) {
                window.console &amp;&amp; console.log(chart_GVBarChartEvents.container.id + ' mouse out at ' + evt.row + ':' + evt.column);
            }
            function fnOnOver(evt) {
                window.console &amp;&amp; console.log(chart_GVBarChartEvents.container.id + ' mouse over at ' + evt.row + ':' + evt.column);
            }
            function fnOnReady() {
                window.console &amp;&amp; console.log(chart_GVBarChartEvents.container.id + ' is ready!');
            }
            function fnOnSelect() {
                try {
                    var chart = chart_GVBarChartEvents;
                    var sel = chart.getSelection();
                    var dt = chart.getData();
                    alert('You selected col[' + sel[0].column + '], row[' + sel[0].row + ']' + 
                    '\nData: ' + dt.getColumnLabel(sel[0].column) + ' was ' + dt.getValue(sel[0].row, sel[0].column) 
                    + ' for ' + dt.getValue(sel[0].row, 0));
                }
                catch (err) {
                    alert('Oops!  OnSelect Error = ' + err);
                }
            }
        &lt;/script&gt;


            Sample Code:
            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            this.GVBarChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            this.GVBarChart1.ChartData(barchart);
        </pre>
        
       
        

        
        
        
        <p />
        <h3>ColumnChart Example with AJAX and Animation and Trendlines</h3>
        <cc1:GVColumnChart ID="GVColumnChart1" runat="server" Width="600" Height="400" GviAnimation_Duration="2000" GviAnimation_Easing="Out"
        QueryString="~/AjaxUpdateHandler.ashx?type=column" GviFormatterHook="MyColumnChartDataFormatter" />
        
        <asp:Button ID="Button1" runat="server" OnClientClick="chart_GVColumnChart1.reload(); return false;" Text="Ajax Reload" />
        
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            this.GVColumnChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            this.GVColumnChart1.ChartData(barchart);
        </pre>
        
        
        <p />
        <h3>ComboChart</h3>

        

        <cc1:GVComboChart ID="GVComboChart1" runat="server"  Width="680" Height="400" GviAnimation_Duration="1000" GviAnimation_Easing="Out"/>
         <pre class="sloppyCode">
            Sample Code:
            DataTable combo = new DataTable("Monthly Coffee Production by Country");
            combo.Columns.Add("Year", typeof(DateTime));
            combo.Columns.Add("Bolivia", typeof(int));
            combo.Columns.Add("Ecuador", typeof(int));
            combo.Columns.Add("Madagascar", typeof(int));
            combo.Columns.Add("Papua New Guinea", typeof(int));
            combo.Columns.Add("Rwanda", typeof(int));
            combo.Columns.Add("Average", typeof(int));

            combo.Rows.Add(new object[] { new DateTime(2004, 5, 1),  165,   938,    522,    998,    450,    614 });
            combo.Rows.Add(new object[] { new DateTime(2004, 6, 1),  135,   1120,   599,    1268,   288,    682 });
            combo.Rows.Add(new object[] { new DateTime(2004, 7, 1),  157,   1167,   587,    807,    397,    623 });
            combo.Rows.Add(new object[] { new DateTime(2004, 8, 1),  139,   1110,   615,    968,    215,    609 });
            combo.Rows.Add(new object[] { new DateTime(2004, 9, 1),  136,   691,    629,    1026,   366,    569 });


            this.GVComboChart1.GviOptionsOverride = "{ seriesType:'bars', series:{5:{type:'line'}} }";

            this.GVComboChart1.DataSource = combo;
            this.GVComboChart1.DataBind();
        </pre>

        
        
        <p />
         <h3>MotionChart Example</h3>
        <cc1:GVMotionChart ID="GVMotionChart1" runat="server" Width="600" Height="400"/>
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable motionchart = new System.Data.DataTable("Example");
            motionchart.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Fruit", typeof(string)),
                new System.Data.DataColumn("Date", typeof(DateTime)),
                new System.Data.DataColumn("Sales", typeof(int)),
                new System.Data.DataColumn("Expenses", typeof(int)),
                new System.Data.DataColumn("Location", typeof(string))
            });

            motionchart.Rows.Add(new object[] { "Apples",   new DateTime(1988,1,1),     1000,   300,    "East"} );
            motionchart.Rows.Add(new object[] { "Oranges",  new DateTime(1988, 1, 1),   1150,   311,    "West" });
            motionchart.Rows.Add(new object[] { "Bananas",  new DateTime(1988, 1, 1),   300,    200,    "West" });
            motionchart.Rows.Add(new object[] { "Apples",   new DateTime(1989, 6, 1),   1200,   250,    "East" });
            motionchart.Rows.Add(new object[] { "Oranges",  new DateTime(1989, 6, 1),   750,    150,    "West" });
            motionchart.Rows.Add(new object[] { "Bananas",  new DateTime(1989, 6, 1),   788,    617,    "West" });

            this.GVMotionChart1.ChartData(motionchart);
        </pre>
        
        
        <p />
        <h3>ScatterChart Example ( <label style="color:Orange">New</label> with Trendline)</h3>
        <cc1:GVScatterChart ID="GVScatterChart1" runat="server" Width="600" Height="400" QueryString="~/AjaxUpdateHandler.ashx?type=GVScatterChart1"/>
         <p />
         <asp:Button ID="Button3" runat="server"  OnClientClick="chart_GVScatterChart1.reload(); return false;" Text="Ajax Reload" />
        
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable scatter = new System.Data.DataTable("Scatter Example");
            scatter.Columns.AddRange( 
                new System.Data.DataColumn[]{
                    new System.Data.DataColumn("Age",typeof(int)), 
                    new System.Data.DataColumn("Weight",typeof(int))
                });
            scatter.Rows.Add(new object[] { 8, 72});
            scatter.Rows.Add(new object[] { 4, 46 });
            scatter.Rows.Add(new object[] { 6, 55 });
            scatter.Rows.Add(new object[] { 9, 78 });
            scatter.Rows.Add(new object[] { 12, 92 });
            scatter.Rows.Add(new object[] { 5, 50 });
            this.GVScatterChart1.GviTitle = "Age vs Weight Comparison";
            this.GVScatterChart1.GviHAxis = "{title: 'Age', minValue: 0, maxValue: 15}";
            this.GVScatterChart1.GviVAxis = "{title: 'Weight', minValue: 0, maxValue: 100}";
            this.GVScatterChart1.ChartData(scatter);
        </pre>
        
       
        <p />
        <h3>Codebehind Examples</h3>
        <asp:PlaceHolder ID="PlaceHolderChart" runat="server" />

        
        
        <p />
        <h3>Gauge Example</h3>
        <cc1:GVGauge ID="GVGauge1" runat="server"  Width="250" Height="150" QueryString="~\AjaxUpdateHandler.ashx?type=gauge"  GviRedFrom="80" GviRedTo="100" GviYellowFrom="50" GviYellowTo="80"/>
        
        <asp:Button ID="ButtonReload" runat="server"  OnClientClick="chart_GVGauge1.reload(); return false;" Text="Ajax Reload" />
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable gauge = new System.Data.DataTable("Computer");
            gauge.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Label",typeof(string)), 
                new System.Data.DataColumn("Value",typeof(int))
            });
            gauge.Rows.Add(new object[] { "Memory", 80 });
            gauge.Rows.Add(new object[] { "CPU", 55 });
            gauge.Rows.Add(new object[] { "Network", 68 });
            this.GVGauge1.ChartData(gauge);
            
            Ajax Code:
            On Chart: QueryString="~\AjaxUpdateHandler.ashx?type=gauge"
            On Button: OnClientClick="chart_GVGauge1.reload(); return false;"
            <asp:Button ID="Button2" runat="server"  OnClientClick="chart_GVGauge1.reload(); return false;" Text="Ajax Reload" />
        </pre>
        
        
         <p />
        <h3>Data Table: Arrow Format Example</h3>
        <cc1:GVTable ID="GVTableArrowFormat1" runat="server" Height="300" Width="400" GviFormatColumn="1" />
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable tblArrow = new System.Data.DataTable("DataTable - Arrow Formatter");
            tblArrow.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Department",typeof(string)), 
                new System.Data.DataColumn("Revenue Change",typeof(float))
            });
            tblArrow.Rows.Add(new object[] { "Sports", 12f });
            tblArrow.Rows.Add(new object[] { "Toys", -7.3f});
            tblArrow.Rows.Add(new object[] { "Electronics", -2.1f });
            tblArrow.Rows.Add(new object[] { "Food", 22.0f });
            this.GVTableArrowFormat1.GviOptionsOverride = "{allowHtml: true, showRowNumber: true}";
            this.GVTableArrowFormat1.DataSource = tblArrow;
        </pre>





         <p />
        <h3>Roles</h3>
        <cc1:GVLineChart ID="GVLineChartForRoles" runat="server" Width="600" Height="400">
        </cc1:GVLineChart>
         <pre class="sloppyCode">
            Chart Role Types: 
             "annotation", "annotationText", "interval", "tooltip", "certainty", "emphasis", "scope"

            Sample Code:
            System.Data.DataTable dt = new System.Data.DataTable("Fashionista Biz");
            dt.Columns.Add("Month");
            dt.Columns.Add("Sales", typeof(int));
            dt.Columns.Add(new DataColumn("sc", typeof(bool)) { Caption = "certainty" });
            dt.Columns.Add(new DataColumn("em", typeof(bool)) { Caption = "emphasis" });
            dt.Columns.Add(new DataColumn("i1", typeof(int)) { Caption = "interval" });
            dt.Columns.Add(new DataColumn("i2", typeof(int)) { Caption = "interval" });
            dt.Columns.Add(new DataColumn("t1") { Caption = "tooltip" });
            dt.Columns.Add("Expenses", typeof(int));
            dt.Columns.Add(new DataColumn("ec", typeof(bool)) { Caption = "certainty" });
            dt.Columns.Add(new DataColumn("t2") { Caption = "tooltip" });

            dt.Rows.Add(new object[] { "April", 1000, true, true, 980, 1010, "Spring Fashion Show Sparks new Interest", 740, true, "" });
            dt.Rows.Add(new object[] { "May", 800, true, false, 780, 822, "", 700, true, "" });
            dt.Rows.Add(new object[] { "June", 750, true, false, 700, 755, "", 980, true, "Stocking up for back to school sale" });
            dt.Rows.Add(new object[] { "July", 820, true, false, 810, 835, "", 900, true, "" });
            dt.Rows.Add(new object[] { "Aug", 1260, false, false, 1100, 1300, "Anticipated back to school shopping to boost sales", 860, false, "" });

            this.GVLineChartForRoles.DataSource = dt;
        </pre>
        
        
        
        <p />
        <h3>Data Table: Bar Format Example</h3>
        <cc1:GVTable ID="GVTableBarFormat1" runat="server"  Height="300" Width="500" GviFormatType="BarFormat" GviFormatColumn="2" />
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable tblBar = new System.Data.DataTable("DataTable - Combo Bar & Arrow Formatter");
            tblBar.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Department",typeof(string)), 
                new System.Data.DataColumn("Manager",typeof(string)),
                new System.Data.DataColumn("Revenue",typeof(int))
            });
            tblBar.Rows.Add(new object[] { "Shoes", "Lady Gaga",10700 });
            tblBar.Rows.Add(new object[] { "Sports", "Reggie Bush",-15200 });
            tblBar.Rows.Add(new object[] { "Toys", "Reggie Bush", 12500 });
            tblBar.Rows.Add(new object[] { "Electronics", "Daft Punk",-2100});
            tblBar.Rows.Add(new object[] { "Food", "Wolfgang Puck", 22600 });
            tblBar.Rows.Add(new object[] { "Art", "Leo Davinci",1100 });
            this.GVTableBarFormat1.GviFormatColumn = 2;
            this.GVTableBarFormat1.GviOptionsOverride = "{allowHtml: true, showRowNumber: true}";
            this.GVTableBarFormat1.DataSource = tblBar;
        </pre>

        <p />
        <h3><label style="color:salmon;">New</label> &nbsp; Timeline</h3>
        <cc1:GVTimeline ID="GVTimeline1" runat="server"  Height="300" Width="500" />
         <pre class="sloppyCode">
            Sample Code:
            DataTable dt = new DataTable("Presidents");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("President", typeof(string)), 
                new DataColumn("Start", typeof(DateTime)), 
                new DataColumn("End", typeof(DateTime))
            });
            dt.Rows.Add(new object[] {"Washington", new DateTime(1789,3,29), new DateTime(1797,2,3) });
            dt.Rows.Add(new object[] { "Adams", new DateTime(1797, 2, 3), new DateTime(1801, 2, 3) });
            dt.Rows.Add(new object[] { "Jefferson", new DateTime(1801, 2, 3), new DateTime(1809, 2, 3) });

            this.GVTimeline1.DataSource = dt;
            this.GVTimeline1.DataBind();
        </pre>
        

         <p />
        <h3><label style="color:salmon;">New</label> &nbsp; Histogram</h3>
        <cc1:GVHistogram ID="GVHistogram1" runat="server"  Height="300" Width="500" />
         <pre class="sloppyCode">
            Sample Code:
             DataTable dt = new DataTable("Length of Dinosaurs (in meters)");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Dinosaur", typeof(string)), 
                new DataColumn("Length", typeof(decimal))
            });

          dt.Rows.Add( new object[] {"Acrocanthosaurus (top-spined lizard)", 12.2});
          dt.Rows.Add( new object[] {"Albertosaurus (Alberta lizard)", 9.1});
          dt.Rows.Add( new object[] {"Allosaurus (other lizard)", 12.2});
          dt.Rows.Add( new object[] {"Apatosaurus (deceptive lizard)", 22.9});
          dt.Rows.Add( new object[] {"Archaeopteryx (ancient wing)", 0.9});
          dt.Rows.Add( new object[] {"Argentinosaurus (Argentina lizard)", 36.6});
          dt.Rows.Add( new object[] {"Baryonyx (heavy claws)", 9.1});
          dt.Rows.Add( new object[] {"Brachiosaurus (arm lizard)", 30.5});
          dt.Rows.Add( new object[] {"Ceratosaurus (horned lizard)", 6.1});
          dt.Rows.Add( new object[] {"Coelophysis (hollow form)", 2.7});
          dt.Rows.Add( new object[] {"Compsognathus (elegant jaw)", 0.9});
          dt.Rows.Add( new object[] {"Deinonychus (terrible claw)", 2.7});
          dt.Rows.Add( new object[] {"Diplodocus (double beam)", 27.1});
          dt.Rows.Add( new object[] {"Dromicelomimus (emu mimic)", 3.4});
          dt.Rows.Add( new object[] {"Gallimimus (fowl mimic)", 5.5});
          dt.Rows.Add( new object[] {"Mamenchisaurus (Mamenchi lizard)", 21.0});
          dt.Rows.Add( new object[] {"Megalosaurus (big lizard)", 7.9});
          dt.Rows.Add( new object[] {"Microvenator (small hunter)", 1.2});
          dt.Rows.Add( new object[] {"Ornithomimus (bird mimic)", 4.6});
          dt.Rows.Add( new object[] {"Oviraptor (egg robber)", 1.5});
          dt.Rows.Add( new object[] {"Plateosaurus (flat lizard)", 7.9});
          dt.Rows.Add( new object[] {"Sauronithoides (narrow-clawed lizard)", 2.0});
          dt.Rows.Add( new object[] {"Seismosaurus (tremor lizard)", 45.7});
          dt.Rows.Add( new object[] {"Spinosaurus (spiny lizard)", 12.2});
          dt.Rows.Add( new object[] {"Supersaurus (super lizard)", 30.5});
          dt.Rows.Add( new object[] {"Tyrannosaurus (tyrant lizard)", 15.2});
          dt.Rows.Add( new object[] {"Ultrasaurus (ultra lizard)", 30.5});
          dt.Rows.Add(new object[] { "Velociraptor (swift robber)", 1.8 });

            this.GVHistogram1.DataSource = dt;
            this.GVHistogram1.DataBind();
        </pre>


        <p />
        <h3>Org Chart Example</h3>
        <cc1:GVOrgChart ID="GVOrgChart1" runat="server" GviAllowCollapse="true" />
         <pre class="sloppyCode">
            Sample Code:
            this.GVOrgChart1.ChartData("Mike R", "", "President/CEO");
            this.GVOrgChart1.ChartData("Helen B", "Mike R", "CFO");
            this.GVOrgChart1.ChartData("Tom N", "Mike R", "VP Construction");
            this.GVOrgChart1.ChartData("Patrick S", "Mike R", "VP Project Management");
            this.GVOrgChart1.ChartData("Greg T", "Mike R", "VP Procurement");
            this.GVOrgChart1.ChartData("Carl Q", "Mike R", "VP Engineering");
            this.GVOrgChart1.ChartData("Sunny R", "Helen B", "IT Manager");
            this.GVOrgChart1.ChartData("Kim C", "Helen B", "Accounting Manager");
            this.GVOrgChart1.ChartData("Sam Fagih", "Carl Q", "Sr. Engineering Manager");
            this.GVOrgChart1.ChartData("Tony M", "Sunny R", "Sr. Software Analyst");
            this.GVOrgChart1.ChartData("Jeff L", "Sunny R", "Sr. Desktop Support");
            this.GVOrgChart1.ChartData("Isaac P", "Sunny R", "Information Systems");
            this.GVOrgChart1.ChartData("Paul L", "Sunny R", "Information Systems");
            this.GVOrgChart1.ChartData("Connie B", "Sunny R", "IT Specialist");
            this.GVOrgChart1.ChartData("David H", "Jeff L", "Desktop Support");
            this.GVOrgChart1.ChartData("Chad T", "Jeff L", "Desktop Support");
            this.GVOrgChart1.ChartData("Julian K", "Tony M", "Jr. Software Analyst");
        </pre>
        
        
         <p />
        <h3>Org Chart Example - with templating</h3>
        <cc1:GVOrgChart ID="GVOrgChart2" runat="server" GviAllowCollapse="true" GviOnSelect="" />
        <pre class="sloppyCode">
        {
            ...
            // this.GVOrgChart2.GviAllowHtml = true;   ' this is turned on automatically by the templating ChartData call
            this.GVOrgChart2.ChartData(quickTemplate("Mike R", "Mike R", "President/CEO", false));
            this.GVOrgChart2.ChartData(quickTemplate("Helen B", "Mike R", "CFO", true));
            this.GVOrgChart2.ChartData(quickTemplate("Tom N", "Mike R", "VP Construction", false));
            this.GVOrgChart2.ChartData(quickTemplate("Patrick S", "Mike R", "VP Project Management", false));
            this.GVOrgChart2.ChartData(quickTemplate("Greg T", "Mike R", "VP Procurement", false));
            this.GVOrgChart2.ChartData(quickTemplate("Carl Q", "Mike R", "VP Engineering", false));
            this.GVOrgChart2.ChartData(quickTemplate("Sunny R", "Helen B", "IT Manager", true));
            this.GVOrgChart2.ChartData(quickTemplate("Kim C", "Helen B", "Accounting Manager", true));
            this.GVOrgChart2.ChartData(quickTemplate("Sam Fagih", "Carl Q", "Sr. Engineering Manager", false));
            this.GVOrgChart2.ChartData(quickTemplate("Tony M", "Sunny R", "Sr. Software Analyst", false));
            this.GVOrgChart2.ChartData(quickTemplate("Jeff L", "Sunny R", "Sr. Desktop Support", false));
            this.GVOrgChart2.ChartData(quickTemplate("Isaac P", "Sunny R", "Information Systems", false));
            this.GVOrgChart2.ChartData(quickTemplate("Paul L", "Sunny R", "Information Systems", false));
            this.GVOrgChart2.ChartData(quickTemplate("Connie B", "Sunny R", "IT Specialist", true));
            this.GVOrgChart2.ChartData(quickTemplate("David H", "Jeff L", "Desktop Support", false));
            this.GVOrgChart2.ChartData(quickTemplate("Chad T", "Jeff L", "Desktop Support", false));
            this.GVOrgChart2.ChartData(quickTemplate("Julian K", "Tony M", "Jr. Software Analyst", false));

        }
        private static string[] quickTemplate(string PersonsName, string ReportsTo, string Title, bool GenderFemale)
        {
            string tpl = string.Format([YOUR TEMPLATE HERE] ,PersonsName, Title, selectImage(GenderFemale));
            return new string[] 
            { 
                string.Format("__keynotshown:{0}",PersonsName.Replace(" ","")),
                tpl,
                string.Format("__keynotshown:{0}",ReportsTo.Replace(" ","")), 
                Title 
            };
        }
        private static string selectImage(bool Gender)
        {
            return Gender ? "female_user.png" : "male_user.png";
        }
        </pre>





         
        
    </div>
    </form>
</body>
</html>
