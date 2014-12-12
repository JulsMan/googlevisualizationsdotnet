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
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.PlaceHolderChart.Controls.Clear();
            codebehindGauge();
            codebehindAreaChart();
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

    }
}