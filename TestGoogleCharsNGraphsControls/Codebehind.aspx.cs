using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TestGoogleCharsNGraphsControls
{
    public partial class Codebehind : System.Web.UI.Page
    {
        const int HT = 200;
        const int WD = 400;
        protected void Page_Load(object sender, EventArgs e)
        {


            this.markupChart();
            this.codebehindGauge();
            this.codebehindLineChart();
            this.codebehindAreaChart();
            this.codebehindHistoChart();
            this.codebehindPieChart();
            this.codebehindAnnotatedTimeline();
        }


        private DataTable getDT()
        {
            System.Data.DataTable dt = new System.Data.DataTable("Computer");
            dt.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Label",typeof(string)), 
                new System.Data.DataColumn("Value",typeof(int))
            });
            dt.Rows.Add(new object[] { "Memory", 80 });
            dt.Rows.Add(new object[] { "CPU", 55 });
            dt.Rows.Add(new object[] { "Network", 68 });

            return dt;
        }
        private void markupChart()
        {
            this.GVGauge1.GviRedFrom = 90;
            this.GVGauge1.GviRedTo = 100;
            this.GVGauge1.GviYellowFrom = 75;
            this.GVGauge1.GviYellowTo = 90;


            this.GVGauge1.DataSource = getDT();
            this.GVGauge1.DataBind();

        }
        private void codebehindGauge()
        {
            GoogleChartsNGraphsControls.GVGauge chart = new GoogleChartsNGraphsControls.GVGauge();
            chart.Width = WD;
            chart.Height = HT;

            chart.GviRedFrom = 90;
            chart.GviRedTo = 100;
            chart.GviYellowFrom = 75;
            chart.GviYellowTo = 90;


            chart.DataSource = getDT();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }

        private void codebehindLineChart()
        {
            GoogleChartsNGraphsControls.GVLineChart chart = new GoogleChartsNGraphsControls.GVLineChart();
            chart.Width = WD;
            chart.Height = HT;

            chart.DataSource = getDT();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }

        private void codebehindAreaChart()
        {
            GoogleChartsNGraphsControls.GVAreaChart chart = new GoogleChartsNGraphsControls.GVAreaChart();
            chart.Width = WD;
            chart.Height = HT;

            chart.DataSource = getDT();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }

        private void codebehindPieChart()
        {
            GoogleChartsNGraphsControls.GVPieChart chart = new GoogleChartsNGraphsControls.GVPieChart();
            chart.Width = WD;
            chart.Height = HT;
            chart.GviIs3D = true;
            chart.DataSource = getDT();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }

        private void codebehindHistoChart()
        {
            GoogleChartsNGraphsControls.GVHistogram chart = new GoogleChartsNGraphsControls.GVHistogram();
            chart.Width = WD;
            chart.Height = HT;
            
            chart.DataSource = getDT();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }


        private void codebehindAnnotatedTimeline()
        {
            GoogleChartsNGraphsControls.GVAnnotatedTimeline chart = new GoogleChartsNGraphsControls.GVAnnotatedTimeline();
            chart.Width = WD;
            chart.Height = HT;

            GoogleChartsNGraphsControls.TimelineEvent[] evts = new GoogleChartsNGraphsControls.TimelineEvent[]
            {
                new GoogleChartsNGraphsControls.TimelineEvent("foo",new DateTime(2014,1,1),80, "Start", "Starting the charting of Foo"),
                new GoogleChartsNGraphsControls.TimelineEvent("foo",new DateTime(2014,1,2),70),
                new GoogleChartsNGraphsControls.TimelineEvent("foo",new DateTime(2014,1,3),90),
                new GoogleChartsNGraphsControls.TimelineEvent("foo",new DateTime(2014,1,4),100, "End", "Ending this look at foo"),
                new GoogleChartsNGraphsControls.TimelineEvent("bar",new DateTime(2014,1,1),66, "Start", "Doing the same for bar"),
                new GoogleChartsNGraphsControls.TimelineEvent("bar",new DateTime(2014,1,2),55),
                new GoogleChartsNGraphsControls.TimelineEvent("bar",new DateTime(2014,1,3),44, "End", "Bar is all completed!"),
            };

            chart.ChartData(evts);
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }
    }
}