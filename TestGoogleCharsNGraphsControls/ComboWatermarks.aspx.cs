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



            loadComboChart(combo);
            loadLineChart(combo);
            loadAreaChart(combo);




        }


        private void loadComboChart(DataTable dt)
        {
            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.AVG,
                LineName = "Average",
                LineWidth = 2,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Area,
                LineColor = System.Drawing.Color.OrangeRed,
                DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.LONG_DASH
            });


            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Bad",
                LineWidth = 3,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Line,
                LineColor = System.Drawing.Color.BlueViolet,
                FixedValue = 450,
                DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.DOTTED
            });

            this.GVComboChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Good",
                LineWidth = 3,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Line,
                LineColor = System.Drawing.Color.DarkGreen,
                FixedValue = 1200,
                DashedLine = GoogleChartsNGraphsControls.ComboChartLineSeries.LINETYPE.SHORT_DASH
            });

            this.GVComboChart1.DataSource = dt;
            this.GVComboChart1.DataBind();
        }



        private void loadLineChart(DataTable dt)
        {
            this.GVLineChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.AVG,
                LineName = "Average",
                LineWidth = 2,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Area,
                LineColor = System.Drawing.Color.OrangeRed
            });


            this.GVLineChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Bad",
                LineWidth = 3,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Area,
                LineColor = System.Drawing.Color.BlueViolet,
                FixedValue = 450
            });

            this.GVLineChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Good",
                LineWidth = 3,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Area,
                LineColor = System.Drawing.Color.DarkGreen,
                FixedValue = 1200
            });

            this.GVLineChart1.DataSource = dt;
            this.GVLineChart1.DataBind();
        }


        private void loadAreaChart(DataTable dt)
        {
            this.GVAreaChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.AVG,
                LineName = "Average",
                LineWidth = 2,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Candlesticks,
                LineColor = System.Drawing.Color.OrangeRed
            });


            this.GVAreaChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Bad",
                LineWidth = 3,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Candlesticks,
                LineColor = System.Drawing.Color.BlueViolet,
                FixedValue = 450
            });

            this.GVAreaChart1.AddNewSeries(new GoogleChartsNGraphsControls.ComboChartLineSeries()
            {
                FunctType = GoogleChartsNGraphsControls.ComboChartLineSeries.FUNCTION_TYPE.FIXED,
                LineName = "Good",
                LineWidth = 3,
                SeriesType = GoogleChartsNGraphsControls.SeriesType.Candlesticks,
                LineColor = System.Drawing.Color.DarkGreen,
                FixedValue = 1200
            });

            this.GVAreaChart1.DataSource = dt;
            this.GVAreaChart1.DataBind();
        }
    }
}