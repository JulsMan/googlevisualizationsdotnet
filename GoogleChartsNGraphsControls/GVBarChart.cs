using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Data;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVBarChart runat=server></{0}:GVBarChart>")]
    [ToolboxBitmap(typeof(GVBarChart))]
    public class GVBarChart : BaseWebControl
    {

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Where to place the axis titles, compared to the chart area. Supported values:
            in - Draw the axis titles inside the the chart area.
            out - Draw the axis titles outside the chart area.
            none - Omit the axis titles.")]
        [DefaultValue("")]
        public string GviAxisTitlesPosition
        {
            get
            {
                string s = (string)ViewState["GviAxisTitlesPosition"];
                return s;
            }

            set
            {
                ViewState["GviAxisTitlesPosition"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The background color for the chart.")]
        [DefaultValue("")]
        public Color? GVIBackgroundColor
        {
            get
            {
                Color? s = (Color?)ViewState["GVIBackgroundColor"];
                return s;
            }

            set
            {
                ViewState["GVIBackgroundColor"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The color of the chart border, as an HTML color string.")]
        [DefaultValue("")]
        public Color? GVIBackgroundColor_stroke
        {
            get
            {
                Color? s = (Color?)ViewState["GVIBackgroundColor_stroke"];
                return s;
            }

            set
            {
                ViewState["GVIBackgroundColor_stroke"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The border width, in pixels.")]
        [DefaultValue(0)]
        public int? GVIBackgroundColor_strokeWidth
        {
            get
            {
                int? s = (int?)ViewState["GVIBackgroundColor_strokeWidth"];
                return s;
            }

            set
            {
                ViewState["GVIBackgroundColor_strokeWidth"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The chart fill color, as an HTML color string.")]
        [DefaultValue("")]
        public Color? GVIBackgroundColor_fill
        {
            get
            {
                Color? s = (Color?)ViewState["GVIBackgroundColor_fill"];
                return s;
            }

            set
            {
                ViewState["GVIBackgroundColor_fill"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("An object with members to configure the placement and size of the chart area (where the chart itself is drawn, excluding axis and legends). Two formats are supported: a number, or a number followed by %. A simple number is a value in pixels; a number followed by % is a percentage. Example: chartArea:{left:20,top:0,width:\"50%\",height:\"75%\"}")]
        [DefaultValue("")]
        public string GviChartArea
        {
            get
            {
                string s = (string)ViewState["GviChartArea"];
                return s;
            }

            set
            {
                ViewState["GviChartArea"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("How far to draw the chart from the left border.")]
        [DefaultValue("")]
        public string GviChartArea_left
        {
            get
            {
                string s = (string)ViewState["GviChartArea_left"];
                return s;
            }

            set
            {
                ViewState["GviChartArea_left"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("How far to draw the chart from the top border.")]
        [DefaultValue("")]
        public string GviChartArea_top
        {
            get
            {
                string s = (string)ViewState["GviChartArea_top"];
                return s;
            }

            set
            {
                ViewState["GviChartArea_top"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Chart area width.")]
        [DefaultValue("")]
        public string GviChartArea_width
        {
            get
            {
                string s = (string)ViewState["GviChartArea_width"];
                return s;
            }

            set
            {
                ViewState["GviChartArea_width"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Chart area height.")]
        [DefaultValue("")]
        public string GviChartArea_height
        {
            get
            {
                string s = (string)ViewState["GviChartArea_height"];
                return s;
            }

            set
            {
                ViewState["GviChartArea_height"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Use this to assign specific colors to each data series. Colors are specified in the Chart API color format. Color i is used for data column i, wrapping around to the beginning if there are more data columns than colors. If variations of a single color is acceptable for all series, use the color option instead.")]
        [DefaultValue("")]
        public Color?[] GviColors
        {
            get
            {
                Color?[] s = (Color?[])ViewState["GviColors"];
                return s;
            }

            set
            {
                ViewState["GviColors"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The default font size, in pixels, of all text in the chart. You can override this using properties for specific chart elements.")]
        [DefaultValue(false)]
        public int? GviFontSize
        {
            get
            {
                int? s = (int?)ViewState["GviFontSize"];
                return s;
            }

            set
            {
                ViewState["GviEnableEvents"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The default font face for all text in the chart. You can override this using properties for specific chart elements.")]
        [DefaultValue("")]
        public string GviFontName
        {
            get
            {
                string s = (string)ViewState["GviFontSize"];
                return s;
            }

            set
            {
                ViewState["GviEnableEvents"] = value;
            }
        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"An object with members to configure various horizontal axis elements. To specify properties of this object, you can use object literal notation, as shown here:
//            {title: 'Hello',  titleTextStyle: {color: '#FF0000'}}")]
//        [DefaultValue("")]
//        public object GviHAxis
//        {
//            get
//            {
//                string s = (string)ViewState["GviHAxis"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"hAxis property that specifies the baseline for the horizontal axis. If the baseline is smaller than the highest grid line or smaller than the lowest grid line, it will be rounded to the closest gridline.")]
//        [DefaultValue("")]
//        public int? GviHAxis_baseline
//        {
//            get
//            {
//                int? s = (int?)ViewState["GviHAxis_baseline"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_baseline"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"hAxis property that specifies the color of the baseline for the horizontal axis. Can be any HTML color string, for example: 'red' or '#00cc00'")]
//        [DefaultValue("")]
//        public Color? GviHAxis_baselineColor
//        {
//            get
//            {
//                Color? s = (Color?)ViewState["GviHAxis_baselineColor"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_baselineColor"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"The direction in which the values along the horizontal axis grow. Specify -1 to reverse the order of the values. (1 or -1)")]
//        [DefaultValue("")]
//        public string GviHAxis_direction
//        {
//            get
//            {
//                string s = (string)ViewState["GviHAxis_direction"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_direction"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"hAxis property that makes the horizontal axis a logarithmic scale (requires all values to be positive). Set to true for yes.")]
//        [DefaultValue("")]
//        public bool? GviHAxis_logScale
//        {
//            get
//            {
//                bool? s = (bool?)ViewState["GviHAxis_logScale"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_logScale"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"An object that specifies the horizontal axis text style. The object has this format:
//            {color: <string>, fontName: <string>, fontSize: <number>}
//            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
//        [DefaultValue("")]
//        public object GviHAxis_textStyle
//        {
//            get
//            {
//                string s = (string)ViewState["GviHAxis_textStyle"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_textStyle"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Position of the horizontal axis text, relative to the chart area. Supported values: 'out', 'in', 'none'.")]
//        [DefaultValue("")]
//        public string GviHAxis_textPosition
//        {
//            get
//            {
//                string s = (string)ViewState["GviHAxis_textPosition"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_textPosition"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"hAxis property that specifies a title for the horizontal axis.")]
//        [DefaultValue("")]
//        public string GviHAxis_title
//        {
//            get
//            {
//                string s = (string)ViewState["GviHAxis_title"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_title"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"An object that specifies the horizontal axis title text style. The object has this format:
//            {color: <string>, fontName: <string>, fontSize: <number>}
//            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
//        [DefaultValue("")]
//        public object GviHAxis_titleTextStyle
//        {
//            get
//            {
//                string s = (string)ViewState["GviHAxis_titleTextStyle"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_titleTextStyle"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"hAxis property that specifies the highest horizontal axis grid line. The actual grid line will be the greater of two values: the maxValue option value, or the highest data value, rounded up to the next higher grid mark.")]
//        [DefaultValue("")]
//        public int? GviHAxis_maxValue
//        {
//            get
//            {
//                int? s = (int?)ViewState["GviHAxis_maxValue"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_maxValue"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"hAxis property that specifies the lowest horizontal axis grid line. The actual grid line will be the lower of two values: the minValue option value, or the lowest data value, rounded down to the next lower grid mark.")]
//        [DefaultValue("")]
//        public int? GviHAxis_minValue
//        {
//            get
//            {
//                int? s = (int?)ViewState["GviHAxis_minValue"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviHAxis_minValue"] = value;
//            }
//        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, bar values are stacked (accumulated).")]
        [DefaultValue(false)]
        public bool? GviIsStacked
        {
            get
            {
                bool? s = (bool?)ViewState["GviIsStacked"];
                return s;
            }

            set
            {
                ViewState["GviIsStacked"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Position and type of legend. Can be one of the following:
            'right' - To the right of the chart.
            'left' - To the left of the chart.
            'top' - Above the chart.
            'bottom' - Below the chart.
            'none' - No legend is displayed.")]
        [DefaultValue("")]
        public string GviLegend
        {
            get
            {
                string s = (string)ViewState["GviLegend"];
                return s;
            }

            set
            {
                ViewState["GviLegend"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"An object that specifies the legend text style. The object has this format:
            {color: <string>, fontName: <string>, fontSize: <number>}
            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
        [DefaultValue("")]
        public object GviLegendTextStyle
        {
            get
            {
                string s = (string)ViewState["GviLegendTextStyle"];
                return s;
            }

            set
            {
                ViewState["GviLegendTextStyle"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, will draw series from bottom to top. The default is to draw top-to-bottom.")]
        [DefaultValue(false)]
        public bool? GviReverseCategories
        {
            get
            {
                bool? s = (bool?)ViewState["GviReverseCategories"];
                return s;
            }

            set
            {
                ViewState["GviReverseCategories"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Text to display above the chart.")]
        [DefaultValue("")]
        public string GviTitle
        {
            get
            {
                string s = (string)ViewState["GviTitle"];
                return s;
            }

            set
            {
                ViewState["GviTitle"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Where to place the chart title, compared to the chart area. Supported values:
            in - Draw the title inside the chart area.
            out - Draw the title outside the chart area.
            none - Omit the title")]
        [DefaultValue("")]
        public string GviTitlePosition
        {
            get
            {
                string s = (string)ViewState["GviTitlePosition"];
                return s;
            }

            set
            {
                ViewState["GviTitlePosition"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"An object that specifies the title text style. The object has this format:
            {color: <string>, fontName: <string>, fontSize: <number>}
            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
        [DefaultValue("")]
        public object GviTitleTextStyle
        {
            get
            {
                string s = (string)ViewState["GviTitleTextStyle"];
                return s;
            }

            set
            {
                ViewState["GviTitleTextStyle"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"An object that specifies the tooltip text style. The object has this format:
            {color: <string>, fontName: <string>, fontSize: <number>}
            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
        [DefaultValue("")]
        public object GviTooltipTextStyle
        {
            get
            {
                string s = (string)ViewState["GviTooltipTextStyle"];
                return s;
            }

            set
            {
                ViewState["GviTooltipTextStyle"] = value;
            }
        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"An object with members to configure various vertical axis elements. To specify properties of this object, you can use object literal notation, as shown here: {title: 'Hello',  titleTextStyle: {color: '#FF0000'}}")]
//        [DefaultValue("")]
//        public object GviVAxis
//        {
//            get
//            {
//                string s = (string)ViewState["GviVAxis"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviVAxis"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"The direction in which the values along the vertical axis grow. Specify -1 to reverse the order of the values.")]
//        [DefaultValue("")]
//        public string GviVAxis_direction
//        {
//            get
//            {
//                string s = (string)ViewState["GviVAxis_direction"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviVAxis_direction"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Position of the vertical axis text, relative to the chart area. Supported values: 'out', 'in', 'none'.")]
//        [DefaultValue("")]
//        public string GviVAxis_textPosition
//        {
//            get
//            {
//                string s = (string)ViewState["GviVAxis_textPosition"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviVAxis_textPosition"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"An object that specifies the vertical axis text style. The object has this format:
//            {color: <string>, fontName: <string>, fontSize: <number>}
//            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
//        [DefaultValue("")]
//        public object GviVAxis_textStyle
//        {
//            get
//            {
//                string s = (string)ViewState["GviVAxis_textStyle"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviVAxis_textStyle"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"vAxis property that specifies a title for the vertical axis.")]
//        [DefaultValue("")]
//        public string GviVAxis_title
//        {
//            get
//            {
//                string s = (string)ViewState["GviVAxis_title"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviVAxis_title"] = value;
//            }
//        }

//        [GviConfigOption]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"An object that specifies the vertical axis text style. The object has this format:
//            {color: <string>, fontName: <string>, fontSize: <number>}
//            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
//        [DefaultValue("")]
//        public object GviVAxis_titleTextStyle
//        {
//            get
//            {
//                string s = (string)ViewState["GviVAxis_titleTextStyle"];
//                return s;
//            }

//            set
//            {
//                ViewState["GviVAxis_titleTextStyle"] = value;
//            }
//        }

        public void ChartData(string Name, int Value)
        {

            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(String));
                this.dt.Columns.Add("Value", typeof(decimal));
            }

            this.dt.Rows.Add(new object[] { Name, (decimal)Value });
        }
        public void ChartData(string Name, decimal Value)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(String));
                this.dt.Columns.Add("Value", typeof(decimal));
            }

            this.dt.Rows.Add(new object[] { Name, Value });
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.BARCHART);
            output.Write(Text);
        }
    }
}
