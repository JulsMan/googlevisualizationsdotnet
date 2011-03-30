using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:GVAnnotatedTimeline runat=server></{0}:GVAnnotatedTimeline>")]
    [ToolboxBitmap(typeof(GVAnnotatedTimeline))]
    public class GVAnnotatedTimeline : BaseWebControl
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
        [Description("If set to true, any annotation text that includes HTML tags will be rendered as HTML.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]

        public TrippleStateBool GviAllowHtml 
        {
            get
            {
                object s = ViewState["GviAllowHtml"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviAllowHtml"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Enables a more efficient redrawing technique for the second and later calls to draw() on this visualization. It only redraws the chart area. To use this option, you must fulfill the following requirements:
        allowRedraw must be true
        displayAnnotations must be false (that is, you cannot show annotations)
        you must pass in the same options and values (except for the allowRedraw and displayAnnotations) as in your first call to draw()")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviAllowRedraw
        {
            get
            {
                object s = ViewState["GviAllowRedraw"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviAllowRedraw"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Description(@"If set to true, the chart will show annotations on top of selected values. When this option is set to true, after every numeric column, two optional annotation string columns can be added, one for the annotation title and one for the annotation text.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayAnnotations
        {
            get
            {
                object s = ViewState["GviDisplayAnnotations"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayAnnotations"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Description(@"If set to true, the chart will display a filter contol to filter annotations. Use this option when there are many annotations")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayAnnotationsFilter
        {
            get
            {
                object s = ViewState["GviDisplayAnnotationsFilter"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayAnnotationsFilter"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Whether to display a small bar separator ( | ) between the series values and the date in the legend, where true means yes.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayDateBarSeparator
        {
            get
            {
                object s = ViewState["GviDisplayDateBarSeparator"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayDateBarSeparator"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Whether to display a shortened, rounded version of the values on the top of the graph, to save space; false indicates that it may. For example, if set to false, 56123.45 might be displayed as 56.12k.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayExactValues
        {
            get
            {
                object s = ViewState["GviDisplayExactValues"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayExactValues"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Whether to display dots next to the values in the legend text, where true means yes.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayLegendDots
        {
            get
            {
                object s = ViewState["GviDisplayExactValues"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayExactValues"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Whether to display the highlighted values in the legend, where true means yes.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayLegendValues
        {
            get
            {
                object s = ViewState["GviDisplayLegendValues"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayLegendValues"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Whether to show the zoom range selection area (the area at the bottom of the chart), where false means no.
            The outline in the zoom selector is a log scale version of the last series in the chart, scaled to fit the height of the zoom selector.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayRangeSelector
        {
            get
            {
                object s = ViewState["GviDisplayRangeSelector"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayRangeSelector"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Description(@"Whether to show the zoom links ('1d 5d 1m' and so on), where false means no.")]
        [Category("GoogleOptions")]
        [DefaultValue(TrippleStateBool.NotSet)]
        public TrippleStateBool GviDisplayZoomButtons
        {
            get
            {
                object s = ViewState["GviDisplayZoomButtons"];
                return s == null ? TrippleStateBool.NotSet : (TrippleStateBool)s;
            }

            set
            {
                ViewState["GviDisplayZoomButtons"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("A suffix to be added to all values in the scales and the legend.")]
        [DefaultValue("")]
        public string GviAllValuesSuffix
        {
            get
            {
                string s = (string)ViewState["GviAllValuesSuffix"];
                return s;
            }

            set
            {
                ViewState["GviAllValuesSuffix"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The format used to display the date information in the top right corner. The format of this field is as specified by the java SimpleDateFormat class.")]
        [DefaultValue("")]
        public string GviDateFormat
        {
            get
            {
                string s = (string)ViewState["GviDateFormat"];
                return s;
            }

            set
            {
                ViewState["GviDateFormat"] = value;
            }
        }

    
        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Which dot on the series to highlight, and corresponding values to show in the legend. Select from one of these values:
            'nearest' - The values closest along the X axis to the mouse.
            'last' - The next set of values to the left of the mouse")]
        public HighlightDot GviHighlightDot
        {

            get
            {
                object s = ViewState["GviHighlightDot"];
                return s == null? HighlightDot.Nearest: (HighlightDot)s;
            }

            set
            {
                ViewState["GviHighlightDot"] = value;
            }
        }
       

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Whether to put the colored legend on the same row with the zoom buttons and the date ('sameRow'), or on a new row ('newRow').")]
        [DefaultValue("")]
        public string GviLegendPosition
        {
            get
            {
                string s = (string)ViewState["GviLegendPosition"];
                return s;
            }

            set
            {
                ViewState["GviLegendPosition"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Specifies the number format patterns to be used to format the values at the top of the graph.
            The patterns should be in the format as specified by the java DecimalFormat class.
            If not specified, the default format pattern is used.
            If a single string pattern is specified, it is used for all of the values.
            If a map is specified, the keys are (zero-based) indexes of series, and the values are the patterns to be used to format the specified series.
            You are not required to include a format for every series on the chart; any unspecified series will use the default format.
            If this option is specified, the displayExactValues option is ignored")]
        [DefaultValue("")]
        public string GviNumberFormats
        {
            get
            {
                string s = (string)ViewState["GviNumberFormats"];
                return s;
            }

            set
            {
                ViewState["GviNumberFormats"] = value;
            }
        }



        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Sets the maximum and minimum values shown on the Y axis. The following options are available:
            'maximized' - The Y axis will span the minimum to the maximum values of the series. If you have more than one series, use allmaximized.
            'fixed' [default] - The Y axis varies, depending on the data values values:
            If all values are >=0, the Y axis will span from zero to the maximum data value.
            If all values are <=0, the Y axis will span from zero to the minimum data value.
            If values are both positive and negative, the Y axis will range from the series maximum to the series minimum.

            For multiple series, use 'allfixed'.
            'allmaximized' - Same as 'maximized,' but used when multiple scales are displayed. Both charts will be maximized within the same scale, which means that one will be misrepresented against the Y axis, but hovering over each series will display it's true value.
            'allfixed' - Same as 'fixed,' but used when multiple scales are displayed. This setting adjusts each scale to the series to which it applies (use this in conjunction with scaleColumns).
            If you specify the min and/or max options, they will take precedence over the minimum and maximum values determined by your scale type.")]
        [DefaultValue("")]
        public string GviScaleType
        {
            get
            {
                string s = (string)ViewState["GviScaleType"];
                return s;
            }

            set
            {
                ViewState["GviScaleType"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The Window Mode (wmode) parameter for the Flash chart. Available values are: 'opaque', 'window' or 'transparent'.")]
        [DefaultValue("")]
        public string GviWmode
        {
            get
            {
                string s = (string)ViewState["GviWmode"];
                return s;
            }

            set
            {
                ViewState["GviWmode"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Sets the end date/time of the selected zoom range.")]
        [DefaultValue("")]
        public DateTime? GviZoomEndTime
        {
            get
            {
                DateTime? s = (DateTime?)ViewState["GviZoomEndTime"];
                return s;
            }

            set
            {
                ViewState["GviZoomEndTime"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Sets the start date/time of the selected zoom range.")]
        [DefaultValue("")]
        public DateTime? GviZoomStartTime
        {
            get
            {
                DateTime? s = (DateTime?)ViewState["GviZoomStartTime"];
                return s;
            }

            set
            {
                ViewState["GviZoomStartTime"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The width (in percent) of the annotations area, out of the entire chart area. Must be a number in the range 5-80.")]
        [DefaultValue(25)]
        public int? GviAnnotationsWidth
        {
            get
            {
                int? s = (int?)ViewState["GviAnnotationsWidth"];
                return s;
            }

            set
            {
                ViewState["GviAnnotationsWidth"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"A number from 0—100 (inclusive) specifying the alpha of the fill below each line in the line graph. 100 means 100% opaque fill, 0 means no fill at all. The fill color is the same color as the line above it.")]
        [DefaultValue(null)]
        public int? GviFill
        {
            get
            {
                int? s = (int?)ViewState["GviFill"];
                return s;
            }

            set
            {
                ViewState["GviFill"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The maximum value to show on the Y axis. If the maximum data point exceeds this value, this setting will be ignored, and the chart will be adjusted to show the next major tick mark above the maximum data point. This will take precedence over the Y axis maximum determined by scaleType.")]
        [DefaultValue(null)]
        public int? GviMax
        {
            get
            {
                int? s = (int?)ViewState["GviMax"];
                return s;
            }

            set
            {
                ViewState["GviMax"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The minimum value to show on the Y axis. If the minimum data point is less than this value, this setting will be ignored, and the chart will be adjusted to show the next major tick mark below the minimum data point. This will take precedence over the Y axis minimum determined by scaleType.")]
        [DefaultValue(null)]
        public int? GviMin
        {
            get
            {
                int? s = (int?)ViewState["GviMin"];
                return s;
            }

            set
            {
                ViewState["GviMin"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"A number from 0—10 (inclusive) specifying the thickness of the lines, where 0 is the thinnest.")]
        [DefaultValue(0)]
        public int? GviThickness
        {
            get
            {
                int? s = (int?)ViewState["GviThickness"];
                return s;
            }

            set
            {
                ViewState["GviThickness"] = value;
            }
        }


        [GviConfigOption]
        [TypeConverter(typeof(WebColorConverter))]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The colors to use for the chart lines and labels. An array of strings. Each element is a string in a valid HTML color format. For example 'red' or '#00cc00'.")]
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
        [Description(@"Specifies which values to show on the Y axis tick marks in the graph. The default is to have a single scale on the right side, which applies to both series; but you can have different sides of the graph scaled to different series values.
            This option takes an array of zero to three numbers specifying the (zero-based) index of the series to use as the scale value. Where these values are shown depends on how many values you include in your array:
            If you specify an empty array, the chart will not show Y values next to the tick marks.
            If you specify one value, the scale of the indicated series will be displayed on the right side of the chart only.
            If you specify two values, a the scale for the second series will be added to the right of the chart.
            If you specify three values, a scale for the third series will be added to the middle of the chart.
            Any values after the third in the array will be ignored.
            When displaying more than one scale, it is advisable to set the scaleType option to either 'allfixed' or 'allmaximized'.")]
        [DefaultValue(0)]
        public int?[] GviScaleColumns
        {
            get
            {
                int?[] s = (int?[])ViewState["GviThickness"];
                return s;
            }

            set
            {
                ViewState["GviThickness"] = value;
            }
        }

       
        public void ChartData(TimelineEvent[] ListOfEvents)
        {

            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                // there always must be a date
                dt.Columns.Add("date", typeof(DateTime));

                // find each unique category ... 
                var q = from s in ListOfEvents.Select(e => e.EventCategory).Distinct()
                        orderby s
                        select s;

                // for each category there will be number, and possibly a annotation(title + description)
                foreach (string category in q)
                {
                    this.dt.Columns.Add(category, typeof(Decimal));
                    this.dt.Columns.Add(category + "_title", typeof(String));
                    this.dt.Columns.Add(category + "_text", typeof(String));
                }
            }


            // group into dates and add em
            var qq = from s in ListOfEvents
                     group s by s.EventDate into g
                     select g;
            
            // IGrouping<DateTime, TimelineEvents>
            foreach (var t in qq)
            {
                var aryOfObjs = from c in t.OrderBy(s => s.EventCategory)
                                          select new { c.YValue, c.OptionalAnnotationTitle, c.OptionalAnnotationText };

                List<object> flatten = new List<object>();
                foreach (var f in aryOfObjs)
                {
                    flatten.Add(f.YValue);
                    flatten.Add(f.OptionalAnnotationTitle);
                    flatten.Add(f.OptionalAnnotationTitle);
                }

                // add the date in the front ...
                flatten.Insert(0, t.Key);

                this.dt.Rows.Add(flatten.ToArray());
            }


            //this.JsonData = gvi.googleDataTableToJson(dt);
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.TIMELINE);
            output.Write(Text);
        }
    }
}
