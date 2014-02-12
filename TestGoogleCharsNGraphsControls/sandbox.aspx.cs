using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace TestGoogleCharsNGraphsControls
{
    public partial class sandbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                columnChart();
                scatterChart();




                

            }
               
        }

        private void timelineChart()
        {
             List<GoogleChartsNGraphsControls.TimelineEvent> evts = new List<GoogleChartsNGraphsControls.TimelineEvent>();
                evts.Add(new GoogleChartsNGraphsControls.TimelineEvent("Sold Pencils", new DateTime(2008, 1, 1), 30000));
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

                //this.GVAnnotatedTimeline1.GviDisplayAnnotations = GoogleChartsNGraphsControls.TrippleStateBool.True;
                //this.GVAnnotatedTimeline1.ChartData(evts.ToArray());
            
        }


        //private void areaChart()
        //{
        //    System.Data.DataTable dt = new System.Data.DataTable("Company Performance");
        //    dt.Columns.Add("Year", typeof(string));
        //    dt.Columns.Add("Sales", typeof(int));
        //    dt.Columns.Add("Expenses", typeof(int));
        //    dt.Rows.Add(new object[] { "2004", 1000, 400 });
        //    dt.Rows.Add(new object[] { "2005", 1170, 460 });
        //    dt.Rows.Add(new object[] { "2006", 660, 1120 });
        //    dt.Rows.Add(new object[] { "2007", 1030, 540 });

        //    this.GVAreaChart1.DataSource = dt;
        //    this.GVAreaChart1.DataBind();

        //    GoogleChartsNGraphsControls.Animation an = new GoogleChartsNGraphsControls.Animation();
        //    an.Easing = GoogleChartsNGraphsControls.AnimationEasing.Out;
        //    an.Duration = 2500;
        //    this.GVAreaChart1.GviAnimationClass = an;

        //    this.GVAreaChart1.GviLegendClass = new GoogleChartsNGraphsControls.Legend() { LegendPosition = GoogleChartsNGraphsControls.LegendPostion.Bottom };

        //    GoogleChartsNGraphsControls.hAxis hx = new GoogleChartsNGraphsControls.hAxis();
        //    hx.Baseline = 1;
        //    hx.BaselineColor = System.Drawing.Color.Red;
        //    hx.SlantedText = true;
        //    hx.Title = "Hoz Axis Title";
        //    this.GVAreaChart1.GviHAxisClass = hx;

        //    GoogleChartsNGraphsControls.vAxis vx = new GoogleChartsNGraphsControls.vAxis();
        //    vx.BaselineColor = System.Drawing.Color.Green;
        //    vx.Formatted = GoogleChartsNGraphsControls.AxisFormat.Euro;
        //    vx.Title = "By Year";
        //    this.GVAreaChart1.GviVAxisClass = vx;
        //}



        private void scatterChart()
        {
            System.Data.DataTable scatter = new System.Data.DataTable("Scatter Example");
            scatter.Columns.AddRange(
            new System.Data.DataColumn[]{
                new System.Data.DataColumn("Age",typeof(int)), 
                new System.Data.DataColumn("Weight",typeof(int))
            });
            scatter.Rows.Add(new object[] { 8, 72 });
            scatter.Rows.Add(new object[] { 4, 46 });
            scatter.Rows.Add(new object[] { 6, 55 });
            scatter.Rows.Add(new object[] { 9, 78 });
            scatter.Rows.Add(new object[] { 12, 92 });
            scatter.Rows.Add(new object[] { 5, 50 });
            this.GVScatterChart1.GviTitle = "Age vs Weight Comparison";

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
            //this.GVScatterChart1.GviHAxis = "{title: 'Age', minValue: 0, maxValue: 15}";
            GoogleChartsNGraphsControls.hAxis hx = new GoogleChartsNGraphsControls.hAxis();
            hx.Title = "Child Age";
            hx.ShowTextEvery = 1;
            hx.SlantedText = true;
            //this.GVScatterChart1.GviVAxis = "{title: 'Weight', minValue: 0, maxValue: 100}";
            this.GVScatterChart1.GviHAxisClass = hx;
            GoogleChartsNGraphsControls.Animation an = new GoogleChartsNGraphsControls.Animation(GoogleChartsNGraphsControls.AnimationEasing.InAndOut, 1000);
            this.GVScatterChart1.GviAnimationClass = an;
            this.GVScatterChart1.DataSource = scatter;
        }


        private void columnChart()
        {
            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            //this.GVBarChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";

        

            //this.GVColumnChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            GoogleChartsNGraphsControls.vAxis vx = new GoogleChartsNGraphsControls.vAxis();
            vx.BaselineColor = Color.Green;
            vx.Formatted = GoogleChartsNGraphsControls.AxisFormat.Euro;
            vx.Title = "By Year";

            GoogleChartsNGraphsControls.TrendLine tl1 = new GoogleChartsNGraphsControls.TrendLine()
            {
                Color = Color.MediumPurple,
                Type = GoogleChartsNGraphsControls.TrendLineType.Exponential,
                LabelInLegend = "Year Trend",
                Opacity = 0.3f,
                LineWidth = 10,
                VisibleInLegend = true
            };
            GoogleChartsNGraphsControls.TrendLine tl2 = new GoogleChartsNGraphsControls.TrendLine()
            {
                Color = Color.Maroon,
                Type = GoogleChartsNGraphsControls.TrendLineType.Linear,
                LabelInLegend = "Sales Trend",
                Opacity = 0.3f,
                LineWidth = 5,
                VisibleInLegend = true
            };
            this.GVColumnChart1.GviTrendLine = new GoogleChartsNGraphsControls.TrendLine[] { tl1, tl2 };
            this.GVColumnChart1.GviVAxisClass = vx;
            this.GVColumnChart1.DataSource = barchart;
        }
    }
}