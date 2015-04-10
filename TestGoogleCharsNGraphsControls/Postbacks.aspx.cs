using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TestGoogleCharsNGraphsControls
{
    public partial class Postbacks : System.Web.UI.Page
    {
        const int WD = 300;
        const int HT = 200;

        protected void Page_Load(object sender, EventArgs e)
        {
            codebehindAreaChart();

            codebehindTable();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.PlaceHolderChart.Controls.Clear();
            codebehindGauge();
            codebehindAreaChart();
        }


        private void codebehindTable()
        {
            GoogleChartsNGraphsControls.GVTable chart = new GoogleChartsNGraphsControls.GVTable();
            chart.Width = WD;
            chart.Height = HT;

            DataTable dt = getData2();
            dt = GoogleChartsNGraphsControls.Utils.PivotData(dt, "Employee", "Length",
                GoogleChartsNGraphsControls.Utils.AggregateFunction.Sum, new string[] { "Type" });

            dt = GoogleChartsNGraphsControls.Utils.AddSummary(dt, "Total", GoogleChartsNGraphsControls.Utils.SUMMARYOPTIONS.BOTH);
            //dt.DefaultView.Sort = "Employee ASC";
            chart.DataSource = dt.DefaultView.ToTable();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

        }

        private void codebehindAreaChart()
        {
            GoogleChartsNGraphsControls.GVAreaChart chart = new GoogleChartsNGraphsControls.GVAreaChart();
            chart.Width = WD;
            chart.Height = HT;
            chart.GviPointShape = GoogleChartsNGraphsControls.PointShape.Triangle;
            chart.GviPointSize = 33;

            chart.DataSource = getDT();
            chart.DataBind();

            this.PlaceHolderChart.Controls.Add(chart);

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

        private DataTable getDT()
        {
            Random rnd = new Random(System.Environment.TickCount);

            System.Data.DataTable dt = new System.Data.DataTable("Computer");
            dt.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Label",typeof(string)), 
                new System.Data.DataColumn("Value",typeof(int))
            });
            dt.Rows.Add(new object[] { "Memory", rnd.Next(100) });
            dt.Rows.Add(new object[] { "CPU", rnd.Next(100) });
            dt.Rows.Add(new object[] { "Network", rnd.Next(100) });

            return dt;
        }


        private DataTable getData2()
        {
            Random rnd = new Random(System.Environment.TickCount);

            System.Data.DataTable dt = new System.Data.DataTable("Meetings");
            dt.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Date",typeof(DateTime)), 
                new System.Data.DataColumn("Employee",typeof(string)),
                new System.Data.DataColumn("Type",typeof(string)),
                new System.Data.DataColumn("Length",typeof(int)),
            });
            dt.Rows.Add(new object[] { new DateTime(2015,1,5), "Julian", "Meeting", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 6), "Julian", "Meeting", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 7), "Naomi", "Meeting", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 8), "Ellie", "Appointment", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 9), "Julian", "All Hands", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 10), "Naomi", "Meeting", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 5), "Julian", "Appointment", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 8), "Naomi", "Appointment", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 14), "Julian", "Appointment", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 22), "Ellie", "Meeting", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 25), "Naomi", "All Hands", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 25), "Zoe", "Appointment", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 13), "Julian", "Appointment", rnd.Next(100) });
            dt.Rows.Add(new object[] { new DateTime(2015, 1, 10), "Naomi", "Meeting", rnd.Next(100) });


            return dt;
        }

    }
}