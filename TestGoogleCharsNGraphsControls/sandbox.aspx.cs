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


                //this.GVColumnChart1.GviLegendClass = new GoogleChartsNGraphsControls.Legend() { LegendPosition = GoogleChartsNGraphsControls.LegendPostion.Bottom };

                GoogleChartsNGraphsControls.hAxis hx = new GoogleChartsNGraphsControls.hAxis();
                hx.SlantedText = true;
                hx.Title = "Hoz Axis Title";
                this.GVColumnChart1.GviHAxisClass = hx;

                //GoogleChartsNGraphsControls.vAxis vx = new GoogleChartsNGraphsControls.vAxis();
                //vx.BaselineColor = System.Drawing.Color.Green;
                //vx.Formatted = GoogleChartsNGraphsControls.AxisFormat.Euro;
                //vx.Title = "By Year";
                //this.GVColumnChart1.GviVAxisClass = vx;

                this.GVColumnChart1.ChartData(dt);
            }
        }
    }
}