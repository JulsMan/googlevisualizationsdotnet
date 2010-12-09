 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examples.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.WebForm1" %>

<%@ Register assembly="GoogleChartsNGraphsControls" namespace="GoogleChartsNGraphsControls" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type='text/javascript' src='http://www.google.com/jsapi'></script>
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
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h3>Map Example</h3>
        <cc1:GVMap ID="GVMap2" runat="server" GVIShowTip="True" Height="300px" 
            Width="600px" GVILineColor="Goldenrod" GVILineWidth="4"/>
            <pre class="sloppyCode">
                Sample Code:
                this.GVMap2.ChartData("Duvall, WA", "Home Sweet Home");
                this.GVMap2.ChartData("Bothell, WA", "Work");
            </pre>
        <p />
        
     
        
        <p />
        <h3>Annotated Timeline Example</h3>
        <cc1:GVAnnotatedTimeline ID="GVAnnotatedTimeline1" runat="server"  Width="800" Height="400" GVIDisplayAnnotations="True" GviDisplayDateBarSeparator="true" GviAllowRedraw="true"/>
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
        <h3>PieChart Example</h3>
        <cc1:GVPieChart ID="GVPieChart1" runat="server" Width="600" Height="400" />
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
        
        <p />
        <h3>PieChart Example</h3>
        <cc1:GVPieChart ID="GVPieChart2" runat="server" Width="600" Height="400" GviTitle="Favorite Pets" GviLegend="left" GviIs3D="true" />
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
        <cc1:GVAreaChart ID="GVAreaChart2" runat="server" Width="600" Height="400" />
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
        <h3>BarChart Example</h3>
        <cc1:GVBarChart ID="GVBarChart1" runat="server" Width="600" Height="400"  />
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
        <h3>ColumnChart Example</h3>
        <cc1:GVColumnChart ID="GVColumnChart1" runat="server" Width="600" Height="400" />
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
         <h3>SparkLine Example</h3>
        <cc1:GVSparkLine ID="GVSparkLine1" runat="server" Width="600" Height="400"/>
         <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable rv = new System.Data.DataTable("Revenue/Licenses");
            rv.Columns.Add("Revenue", typeof(int));
            rv.Columns.Add("Licenses", typeof(int));
            rv.Rows.Add(new object[] { 435, 132 });
            rv.Rows.Add(new object[] { 438, 131 });
            rv.Rows.Add(new object[] { 512, 137 });
            rv.Rows.Add(new object[] { 460, 142 });
            rv.Rows.Add(new object[] { 491, 140 });
            rv.Rows.Add(new object[] { 487, 139 });
            rv.Rows.Add(new object[] { 552, 147 });
            rv.Rows.Add(new object[] { 511, 146 });
            rv.Rows.Add(new object[] { 505, 151 });
            rv.Rows.Add(new object[] { 509, 149 });
            this.GVSparkLine1.GviLabelPosition = "left";
            this.GVSparkLine1.ChartData(rv);
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
        <h3>ScatterChart Example</h3>
        <cc1:GVScatterChart ID="GVScatterChart1" runat="server" Width="600" Height="400"/>
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
         <h3>GeoMap Example</h3>
        <cc1:GVGeoMap ID="GVGeoMap1" runat="server" Width="400" Height="400" GviDataMode="regions" GviRegion="world"/>
        <pre class="sloppyCode">
            Sample Code:
            System.Data.DataTable world = new System.Data.DataTable("World Population");
            world.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Country",typeof(string)), 
                new System.Data.DataColumn("Population",typeof(int))
            });
            world.Rows.Add(new object[] { "Germany", 200 });
            world.Rows.Add(new object[] { "United States", 350 });
            world.Rows.Add(new object[] { "Brazil", 250 });
            world.Rows.Add(new object[] { "Canada", 75 });
            world.Rows.Add(new object[] { "France", 290 });
            world.Rows.Add(new object[] { "Russia", 700 });
            world.Rows.Add(new object[] { "China", 1300 });
            world.Rows.Add(new object[] { "India", 1000 });

            
            this.GVGeoMap1.ChartData(world);
        </pre>
        
        <h3>GeoMap Example - Working Out of the Box</h3>
        <cc1:GVGeoMap ID="GVGeoMap2" runat="server" Width="400" Height="400" />
        
        <p />
        <h3>GeoMap Example - Using 'Markers' and 'US' Country</h3>
        <asp:HyperLink ID="HyperLinkGeoBug" runat="server" NavigateUrl="~/GeoBug.aspx">View Example (for some reason this won't run in the same page)</asp:HyperLink>
        
        <pre class="sloppyCode">
          System.Data.DataTable projs = new System.Data.DataTable("US Projects");
            projs.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("City",typeof(string)), 
                new System.Data.DataColumn("Completion",typeof(int)),
                new System.Data.DataColumn("Comments",typeof(string)) 
            });
            projs.Rows.Add(new object[] { "Astoria, NY", 95, "Astoria: Almost Done" });
            projs.Rows.Add(new object[] { "Novato, CA", 35, "Novato: Just Starting" });
            projs.Rows.Add(new object[] { "Duvall, WA", 10, "Duvall: Just Starting" });

            this.GVGeoMap2.GviOptionsOverride = "{'region':'US','colors':[0xFF8747, 0xFFB581, 0xc06000], 'dataMode':'markers'}";
            this.GVGeoMap2.ChartData(projs);
        </pre>
        
        <p />
        <h3>Gauge Example</h3>
        <cc1:GVGauge ID="GVGauge1" runat="server"  Width="250" Height="150"/>
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
        <cc1:GVOrgChart ID="GVOrgChart2" runat="server" GviAllowCollapse="true" />
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
