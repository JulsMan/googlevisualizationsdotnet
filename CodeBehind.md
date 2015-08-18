
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace TestGoogleCharsNGraphsControls
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Init()
        {



            // Map Test
            this.GVMap2.ChartData("Duvall, WA", "Home Sweet Home");
            this.GVMap2.ChartData("Bothell, WA", "Work");



            // AnnotatedTimeline Test
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
            this.GVAnnotatedTimeline2.ChartData(evts.Where(d => d.EventCategory == "Sold Erasers").ToArray());
            


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


            System.Data.DataTable dt = new System.Data.DataTable("Work Day");
            dt.Columns.Add("Activity");
            dt.Columns.Add("Daily Percentage", typeof(int));
            dt.Rows.Add(new object[] {"Engineering",5});
            dt.Rows.Add(new object[] { "Programming", 3 });
            dt.Rows.Add(new object[] { "Sleeping", 1 });
            dt.Rows.Add(new object[] { "Lunch", 1 });
            dt.Rows.Add(new object[] { "Meetings", 1 });

            this.GVPieChart1.DataSource = dt;

            this.GVPieChart2.GviTitle = "Where I Spend My Time";
            this.GVPieChart2.GviLegend = "right";
            this.GVPieChart2.GviIs3D = true;
            this.GVPieChart2.DataSource = dt;

          

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

            this.GVAreaChart2.DataSource = dt2;
            
            GoogleChartsNGraphsControls.hAxis hx = new GoogleChartsNGraphsControls.hAxis();
            hx.SlantedText = true;
            hx.Title = "Hoz Axis Title";
            this.GVAreaChart2.GVIHAxisClass = hx;

            GoogleChartsNGraphsControls.Animation an = new GoogleChartsNGraphsControls.Animation();
            an.Easing = GoogleChartsNGraphsControls.AnimationEasing.Out;
            an.Duration = 1000;
            this.GVAreaChart2.GviAnimationOptions = an;



            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            //this.GVBarChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";

            hx = new GoogleChartsNGraphsControls.hAxis();
            hx.Title = "In Thousands";
            hx.Formatted = GoogleChartsNGraphsControls.AxisFormat.Currency;
            hx.SlantedText = true;
            this.GVBarChart1.GVIHAxisClass = hx;

            this.GVBarChart1.GviColors = new System.Drawing.Color?[] { Color.MediumAquamarine, Color.LightCyan };
            this.GVBarChart1.DataSource = barchart;



            //this.GVColumnChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            GoogleChartsNGraphsControls.vAxis vx = new GoogleChartsNGraphsControls.vAxis();
            vx.BaselineColor = Color.Green;
            vx.Formatted = GoogleChartsNGraphsControls.AxisFormat.Euro;
            vx.Title = "By Year";
            this.GVColumnChart1.GVIVAxisClass = vx;
            this.GVColumnChart1.DataSource = barchart;


            //System.Data.DataTable gnattchart = new System.Data.DataTable("Something Performance");
            //gnattchart.Columns.Add("Year", typeof(string));
            //gnattchart.Columns.Add("Something", typeof(int));
            //gnattchart.Rows.Add(new object[] { "2004", 400 });
            //gnattchart.Rows.Add(new object[] { "2005", 460 });
            //gnattchart.Rows.Add(new object[] { "2006", 1120 });
            //gnattchart.Rows.Add(new object[] { "2007", 540 });
            //this.GVGanttChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'blue'} }";
            //this.GVGanttChart1.GviColors = new System.Drawing.Color?[] { Color.DeepPink, Color.Violet, Color.Turquoise, Color.Salmon };
            //this.GVGanttChart1.DataSource = gnattchart;



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
            this.GVSparkLine1.DataSource = rv;



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
            this.GVMotionChart1.DataSource = motionchart;



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
            //this.GVScatterChart1.GviHAxis = "{title: 'Age', minValue: 0, maxValue: 15}";
            hx = new GoogleChartsNGraphsControls.hAxis();
            hx.Title = "Child Age";
            hx.ShowTextEvery = 1;
            hx.SlantedText = true;
            //this.GVScatterChart1.GviVAxis = "{title: 'Weight', minValue: 0, maxValue: 100}";
            this.GVScatterChart1.GVIHAxisClass = hx;
            an = new GoogleChartsNGraphsControls.Animation(GoogleChartsNGraphsControls.AnimationEasing.InAndOut, 1000);
            this.GVScatterChart1.GviAnimationOptions = an;
            this.GVScatterChart1.DataSource = scatter;



           



            //System.Data.DataTable projs = new System.Data.DataTable("US Projects");
            //projs.Columns.AddRange(new System.Data.DataColumn[] {
            //    new System.Data.DataColumn("City",typeof(string)), 
            //    new System.Data.DataColumn("Completion",typeof(int)),
            //    new System.Data.DataColumn("Comments",typeof(string)) 
            //});
            //projs.Rows.Add(new object[] { "Astoria, NY", 95, "Astoria: Almost Done" });
            //projs.Rows.Add(new object[] { "Novato, CA", 35, "Novato: Just Starting" });
            //projs.Rows.Add(new object[] { "Duvall, WA", 10, "Duvall: Just Starting" });

            //this.GVGeoMap3.GviOptionsOverride = "{'region':'US','colors':[0xFF8747, 0xFFB581, 0xc06000], 'dataMode':'markers'}";
            //this.GVGeoMap3.DataSource = projs;



            System.Data.DataTable gauge = new System.Data.DataTable("Computer");
            gauge.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Label",typeof(string)), 
                new System.Data.DataColumn("Value",typeof(int))
            });
            gauge.Rows.Add(new object[] { "Memory", 80 });
            gauge.Rows.Add(new object[] { "CPU", 55 });
            gauge.Rows.Add(new object[] { "Network", 68 });

            this.GVGauge1.GviRedFrom = 90;
            this.GVGauge1.GviRedTo = 100;
            this.GVGauge1.GviYellowFrom = 75;
            this.GVGauge1.GviYellowTo = 90;
            this.GVGauge1.DataSource = gauge;



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



            System.Data.DataTable tblBar = new System.Data.DataTable("DataTable - Bar + Arrow Formatter");
            tblBar.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Department",typeof(string)), 
                new System.Data.DataColumn("Manager",typeof(string)),
                new System.Data.DataColumn("Revenue",typeof(int)),
                new System.Data.DataColumn("Revenue Change",typeof(float))
            });
            tblBar.Rows.Add(new object[] { "Shoes", "Lady Gaga",10700, 12f });
            tblBar.Rows.Add(new object[] { "Sports", "Reggie Bush",-15200, -7.3f });
            tblBar.Rows.Add(new object[] { "Toys", "Reggie Bush", 12500, 2.1f });
            tblBar.Rows.Add(new object[] { "Electronics", "Daft Punk",-2100, -6.3});
            tblBar.Rows.Add(new object[] { "Food", "Wolfgang Puck", 22600, 5.3f });
            tblBar.Rows.Add(new object[] { "Art", "Leo Davinci",1100, 44.3f });
            
            this.GVTableBarFormat1.GviFormatColumn = 2;
            this.GVTableBarFormat1.GviOptionsOverride = "{allowHtml: true, showRowNumber: true}";

            this.GVTableBarFormat1.GviFormatter.Add(
                new GoogleChartsNGraphsControls.TableFormatter() 
                { 
                    Formatter = GoogleChartsNGraphsControls.TableFormatter.FormatType.ArrowFormat, 
                    GviFormatColumn = 3 
                });
            this.GVTableBarFormat1.DataSource = tblBar;




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
            string tpl = string.Format("<div><img style=\"width:33px;height:33px;\" src=\"./App_Themes/{2}\" alt=\"Missing Photo\"></img></div>{0}<div style=\"color:red; font-style:italic\">{1}</div>",
                PersonsName, Title, selectImage(GenderFemale));
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












        protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Random rand = new Random(Environment.TickCount);

                System.Data.DataTable dt = new System.Data.DataTable("Work Day");
                dt.Columns.Add("Activity");
                dt.Columns.Add("Daily Percentage", typeof(int));
                dt.Rows.Add(new object[] { "Engineering", rand.Next(1,10) });
                dt.Rows.Add(new object[] { "Programming", rand.Next(1, 10) });
                dt.Rows.Add(new object[] { "Sleeping", rand.Next(1, 10) });
                dt.Rows.Add(new object[] { "Lunch", rand.Next(1, 10) });
                dt.Rows.Add(new object[] { "Meetings", rand.Next(1, 10) });

                this.GVPieChart1.DataSource = dt;

                this.GVPieChart1.GviTitle = string.Format("My Time: {0}", DateTime.Now.ToShortTimeString());
                this.GVPieChart1.GviLegend = "right";
                this.GVPieChart1.GviIs3D = true;
                this.GVPieChart1.DataSource = dt;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}

```