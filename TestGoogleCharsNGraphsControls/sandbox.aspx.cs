using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoogleCharsNGraphsControls
{
    public partial class sandbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Data.DataTable dt = new System.Data.DataTable("Company Performance");
                dt.Columns.Add("Year", typeof(string));
                dt.Columns.Add("Sales", typeof(int));
                dt.Columns.Add("Expenses", typeof(int));
                dt.Rows.Add(new object[] { "2004", 1000, 400 });
                dt.Rows.Add(new object[] { "2005", 1170, 460 });
                dt.Rows.Add(new object[] { "2006", 660, 1120 });
                dt.Rows.Add(new object[] { "2007", 1030, 540 });



                //GoogleChartsNGraphsControls.Animation an = new GoogleChartsNGraphsControls.Animation();
                //an.Easing = GoogleChartsNGraphsControls.AnimationEasing.Out;
                //an.Duration = 2500;
                //this.GVColumnChart1.GviAnimationClass = an;

                this.GVAreaChart1.DataSource = dt;
                this.GVAreaChart1.DataBind();
                //this.GVColumnChart1.GviLegendClass = new GoogleChartsNGraphsControls.Legend() { LegendPosition = GoogleChartsNGraphsControls.LegendPostion.Bottom };

                GoogleChartsNGraphsControls.hAxis hx = new GoogleChartsNGraphsControls.hAxis();
                hx.Baseline = 1;
                hx.BaselineColor = System.Drawing.Color.Red;
                hx.SlantedText = true;
                hx.Title = "Hoz Axis Title";
                this.GVAreaChart1.GviHAxisClass = hx;

                GoogleChartsNGraphsControls.vAxis vx = new GoogleChartsNGraphsControls.vAxis();
                vx.BaselineColor = System.Drawing.Color.Green;
                vx.Formatted = GoogleChartsNGraphsControls.AxisFormat.Euro;
                vx.Title = "By Year";
                this.GVAreaChart1.GviVAxisClass = vx;


                


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
                this.GVAnnotatedTimeline1.ChartData(evts.ToArray());
            }
        }
    }
}