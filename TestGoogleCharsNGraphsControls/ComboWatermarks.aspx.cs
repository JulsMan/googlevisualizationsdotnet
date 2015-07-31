using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoogleCharsNGraphsControls
{
    public partial class ComboWatermarks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable combo = new DataTable("Monthly Coffee Production by Country");
            combo.Columns.Add("Year", typeof(DateTime));
            combo.Columns.Add("Bolivia", typeof(int));
            combo.Columns.Add("Ecuador", typeof(int));
            combo.Columns.Add("Madagascar", typeof(int));
            combo.Columns.Add("Papua New Guinea", typeof(int));
            combo.Columns.Add("Rwanda", typeof(int));


            combo.Rows.Add(new object[] { new DateTime(2004, 5, 1), 165, 938, 522, 998, 450 });
            combo.Rows.Add(new object[] { new DateTime(2004, 6, 1), 135, 1120, 599, 1268, 288 });
            combo.Rows.Add(new object[] { new DateTime(2004, 7, 1), 157, 1167, 587, 807, 397 });
            combo.Rows.Add(new object[] { new DateTime(2004, 8, 1), 139, 1110, 615, 968, 215 });
            combo.Rows.Add(new object[] { new DateTime(2004, 9, 1), 136, 691, 629, 1026, 366 });

            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.WaterMarkLine(System.Drawing.Color.Honeydew, 300));
            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Ceiling", LineWidth = 4,
                FixedValue = 1000,
                DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.SHORT_DASH,
                LineColor = System.Drawing.Color.Gray
            });

            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.AVG,
                LineName = "Average", LineWidth = 2, DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.DOTTED,
                LineColor = System.Drawing.Color.OrangeRed
            });


            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.STD_DEV,
                LineName = "StdDev",
                LineWidth = 2,
                DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.DOTTED,
                LineColor = System.Drawing.Color.PaleGoldenrod
            });


            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.MEDIAN,
                LineName = "Median",
                LineWidth = 2,
                DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.DOTTED,
                LineColor = System.Drawing.Color.Violet
            });
            

            //this.GVComboChart1.GviOptionsOverride = "{ seriesType:'bars', series:{ 3:{type:'line'}, 4:{type:'line'} } }";
            //this.GVComboChart1.GviComboChartLine = new GoogleChartsNGraphsControls.ComboChartLineSeries()
            //{
            //    Column = 5,
            //    LineType = GoogleChartsNGraphsControls.SeriesType.Line
            //};
            this.GVComboChart1.DataSource = combo;
            this.GVComboChart1.DataBind();

        }
    }
}