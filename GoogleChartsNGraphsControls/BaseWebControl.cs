using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DataContract]
    public abstract class BaseWebControl : WebControl, IPostBackEventHandler, IGviChart
    {
        public BaseWebControl()
        {
            this.GviAnimationClass = null;
            this.GviHAxisClass = null;
        }

        protected BaseGVI gvi = new BaseGVI();

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
        [Description("Text to display above the chart.")]
        [DataMember(Name="title", EmitDefaultValue=true, IsRequired=false)]
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
        [Description(@"A theme is a set of predefined option values that work together to achieve a specific chart behavior or visual effect. Currently only one theme is available:
            'maximized' - Maximizes the area of the chart, and draws the legend and all of the labels inside the chart area. Sets the following options:")]
        [DefaultValue(TitlePosition.Out)]
        [DataMember(Name = "titlePosition", EmitDefaultValue = true, IsRequired = false)]
        public TitlePosition GVITitlePosition
        {
            get
            {
                object s = ViewState["GVITitlePosition"];
                if (s == null) return TitlePosition.Out;
                TitlePosition ss = (TitlePosition)ViewState["GVITitlePosition"];
                return ss;
            }
            set
            {
                ViewState["GVITitlePosition"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"An object that specifies the title text style. The object has this format:
            {color: <string>, fontName: <string>, fontSize: <number>}
            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
        [DefaultValue("")]
        [DataMember(Name = "titleTextStyle", IsRequired = false, EmitDefaultValue = true)]
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
        [Description(@"Override the GviOptions here by entering your own options JSON.  If this is used then other config options will ignored.")]
        [DefaultValue(null)]
        public string GviOptionsOverride
        {
            get
            {
                string s = (string)ViewState["GviOptionsOverride"];
                return s;
            }

            set
            {
                ViewState["GviOptionsOverride"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The background color for the chart.")]
        [DefaultValue(null)]
        //[Newtonsoft.Json.JsonProperty(PropertyName = "backgroundColor", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, TypeNameHandling=Newtonsoft.Json.TypeNameHandling.Objects )]
        //[Newtonsoft.Json.JsonConverter(typeof(Color?))]
        [DataMember(Name = "backgroundColor", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "backgroundColor.stroke", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "backgroundColor.strokeWidth", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "backgroundColor.fill", EmitDefaultValue = true, IsRequired = false)]
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
        [Description("Whether the chart throws user-based events or reacts to user interaction. If false, the chart will not throw 'select' or other interaction-based events (but will throw ready or error events), and will not display hovertext or otherwise change depending on user input.")]
        [DefaultValue(true)]
        [DataMember(Name = "enableInteractivity", EmitDefaultValue = true, IsRequired = false)]
        public bool? GVIEnableInteractivity
        {
            get
            {
                return (bool?)ViewState["GVIEnableInteractivity"];
            }
            set
            {
                ViewState["GVIEnableInteractivity"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The type of the entity that receives focus on mouse hover. Also affects which entity is selected by mouse click, and which data table element is associated with events. Can be one of the following:
            'datum' - Focus on a single data point. Correlates to a cell in the data table.
            'category' - Focus on a grouping of all data points along the major axis. Correlates to a row in the data table.
            In focusTarget 'category' the tooltip displays all the category values. This may be useful for comparing values of different series.")]
        [DefaultValue(FocusTarget.Default)]
        [DataMember(Name = "focusTarget", EmitDefaultValue = true, IsRequired = false)]
        public FocusTarget GVIFocusTarget
        {
            get
            {
                object s = ViewState["GVIFocusTarget"];
                if (s == null) return FocusTarget.Default;
                FocusTarget ss = (FocusTarget)ViewState["GVIFocusTarget"];
                return ss;
            }
            set
            {
                ViewState["GVIFocusTarget"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("An object with members to configure the placement and size of the chart area (where the chart itself is drawn, excluding axis and legends). Two formats are supported: a number, or a number followed by %. A simple number is a value in pixels; a number followed by % is a percentage. Example: chartArea:{left:20,top:0,width:\"50%\",height:\"75%\"}")]
        [DefaultValue("")]
        [DataMember(Name = "chartArea", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "chartArea.left", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "chartArea.top", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "chartArea.width", EmitDefaultValue = true, IsRequired = false)]
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
        [DataMember(Name = "chartArea.height", EmitDefaultValue = true, IsRequired = false)]
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
        [Description(@"If set to true, will draw series from bottom to top. The default is to draw top-to-bottom.")]
        [DefaultValue(false)]
        [DataMember(Name = "reverseCategories", EmitDefaultValue = true, IsRequired = false)]
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
        [Description("The default font size, in pixels, of all text in the chart. You can override this using properties for specific chart elements.")]
        [DefaultValue(false)]
        [DataMember(Name = "fontSize", IsRequired = false, EmitDefaultValue = true)]
        public int? GviFontSize
        {
            get
            {
                int? s = (int?)ViewState["GviFontSize"];
                return s;
            }

            set
            {
                ViewState["GviFontSize"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The default font face for all text in the chart. You can override this using properties for specific chart elements.")]
        [DefaultValue("")]
        [DataMember(Name = "fontName", IsRequired = false, EmitDefaultValue = true)]
        public string GviFontName
        {
            get
            {
                string s = (string)ViewState["GviFontName"];
                return s;
            }

            set
            {
                ViewState["GviFontName"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Use this to assign specific colors to each data series. Colors are specified in the Chart API color format. Color i is used for data column i, wrapping around to the beginning if there are more data columns than colors. If variations of a single color is acceptable for all series, use the color option instead.")]
        [DefaultValue("")]
        //[Newtonsoft.Json.JsonProperty(PropertyName = "colors", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember(Name = "colors", EmitDefaultValue = true, IsRequired = false)]
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


        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Use this to assign specific colors to each data series. Colors are specified in the Chart API color format. Color i is used for data column i, wrapping around to the beginning if there are more data columns than colors. If variations of a single color is acceptable for all series, use the color option instead.")]
        [DefaultValue("")]
        public string GviColorsByName
        {
            get
            {
                Color?[] colors = ViewState["GviColors"] as Color?[];
                if ((colors != null) && (colors.Length > 0))
                    return string.Join(" ",
                        colors.Select(c => c.Value.Name).ToArray());
                return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                char[] seperators = new char[] { ' ', ';', ',', '|', '+', '-', '/' };
                string[] colorsbyname = new string[] { };
                foreach (char s in seperators)
                {
                    colorsbyname = value.Split(s);
                    if (value.Split(s).Length > 0)
                        break;
                }

                List<Color?> colors = new List<Color?>();
                foreach (string name in colorsbyname)
                {
                    try
                    {
                        Color? c = Color.FromName(name) as Color?;
                        if (c != null)
                            colors.Add(c);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                GviColors = colors.ToArray();
            }
        }

        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description(@"Write a javascript function that inherits 'chart' and registers the events you want...")]
        //[DefaultValue(null)]
        //public object GviRegisterEvents
        //{
        //    get
        //    {
        //        object s = (object)ViewState["GviRegisterEvents"];
        //        return s;
        //    }

        //    set
        //    {
        //        ViewState["GviRegisterEvents"] = value;
        //    }
        //}

        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Overrides the name of the element being replaced in the DOM with this chart.")]
        [DefaultValue("")]
        public string OverrideElementId
        {
            get
            {
                string s = (string)ViewState["OverrideElementId"];
                return s;
            }

            set
            {
                ViewState["OverrideElementId"] = value;
            }
        }

        [Bindable(true)]
        [Category("AjaxExtensions")]
        [Description(@"The URL query string associated with this control from which it will GET its data.")]
        [DefaultValue("")]
        public string QueryString
        {
            get
            {
                string s = (string)ViewState["QueryString"];
                return s;
            }

            set
            {
                ViewState["QueryString"] = value;
            }
        }

        [GviConfigOption]
        //[GviClass("animation")]
        [Bindable(true)]
        [Category("AjaxExtensions")]
        [Description(@"JSON class for animation of charts")]
        [DefaultValue("")]
        public string GviAnimation
        {
            get
            {
                if (this.GviAnimationClass == null)
                    return (string)ViewState["GviAnimationClass"];
                else
                    return this.GviAnimationClass.ToString();
            }

            set
            {
                ViewState["GviAnimationOptions"] = value;
            }
        }

        [DataMember(Name="animation")]
        public Animation GviAnimationClass
        {
            get;
            set;
        }

        [GviAnimationOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The duration of the animation, in milliseconds. For details, see the animation documentation.")]
        public int? GviAnimation_Duration
        {
            get
            {
                if (this.GviAnimationClass == null)
                    this.GviAnimationClass = new Animation();

                return this.GviAnimationClass.Duration;
            }

            set
            {
                if (this.GviAnimationClass == null)
                    this.GviAnimationClass = new Animation();

                this.GviAnimationClass.Duration = value;
            }
        }

        [GviAnimationOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The easing function applied to the animation. The following options are available:
            'linear' - Constant speed.
            'in' - Ease in - Start slow and speed up.
            'out' - Ease out - Start fast and slow down.
            'inAndOut' - Ease in and out - Start slow, speed up, then slow down.")]
        public AnimationEasing GviAnimation_Easing
        {
            get
            {
                if (this.GviAnimationClass == null)
                    this.GviAnimationClass = new Animation();

                return this.GviAnimationClass.Easing;
            }

            set
            {
                if (this.GviAnimationClass == null)
                    this.GviAnimationClass = new Animation();

                this.GviAnimationClass.Easing = value;
            }
        }


        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Hooks into the rendering of the chart.  The data is passed to your hook before being rendered into the chart view.
                Your function should have the following signature fn(chart, data);
                ie.  
                    fn(chart,data){
                        var formatter = new google.visualization.NumberFormat({prefix: '$'});
                        formatter.format(data, 1); // Apply formatter to second column
                    }   
                ")]
        [DefaultValue(null)]
        public string GviFormatterHook
        {
            get
            {
                string s = (string)ViewState["GviFormatterHook"];
                return s;
            }

            set
            {
                ViewState["GviFormatterHook"] = value;
            }
        }


        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Hooks into the rendering of the chart.  The data is passed to your hook before being rendered into the chart view.
                Your function should have the following signature fn(chart, view);
                ie.  
                    fn(chart, dataView){
                        dataView.setColumns([{calc: function(data, row) { return data.getFormattedValue(row, 0); }, type:'string'}, 1]);
                    }   
                ")]
        [DefaultValue(null)]
        public string GviViewFormatHook
        {
            get
            {
                string s = (string)ViewState["GviViewFormatHook"];
                return s;
            }

            set
            {
                ViewState["GviViewFormatHook"] = value;
            }
        }

        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description(@"")]
        //[DefaultValue(null)]
        //public string GviFormatHAxis
        //{
        //    get
        //    {
        //        string s = (string)ViewState["GviViewFormatHook"];
        //        return s;
        //    }

        //    set
        //    {
        //        ViewState["GviViewFormatHook"] = value;
        //    }
        //}

        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description(@"")]
        //[DefaultValue(null)]
        //public string GviFormatVAxis
        //{
        //    get
        //    {
        //        if (this.GVIHAxisClass == null)
        //            return (string)ViewState["GviViewFormatHook"];
        //        else
        //            return this.GVIHAxisClass.ToString();
        //    }

        //    set
        //    {
        //        ViewState["GviViewFormatHook"] = value;
        //    }
        //}


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The maximal value to show in the Y axis.")]
        [DefaultValue(null)]
        [DataMember(Name = "max", IsRequired = false, EmitDefaultValue = true)]
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
        [Description("The minimal value to show in the Y axis.")]
        [DefaultValue(null)]
        [DataMember(Name="min", IsRequired=false, EmitDefaultValue=true)]
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

        [DataMember(Name = "hAxis", EmitDefaultValue = true, IsRequired = false)]
        public hAxis GviHAxisClass
        {
            get;
            set;
        }

        [GviConfigOption]
        //[GviClass("hAxis")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"JSON for hAxis")]
        [DefaultValue("")]
        public string GviHAxis
        {
            get
            {
                if (this.GviHAxisClass == null)
                    return (string)ViewState["GviHAxisClass"];
                else
                    return this.GviHAxisClass.ToString();
            }

            set
            {
                ViewState["GviHAxisClass"] = value;
            }
        }
       
        [DataMember(Name = "vAxis", EmitDefaultValue = true, IsRequired = false)]
        public vAxis GviVAxisClass
        {
            get;
            set;
        }


        [GviConfigOption]
        //[GviClass("vAxis")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"JSON for vAxis")]
        [DefaultValue("")]
        public string GviVAxis
        {
            get
            {
                if (this.GviVAxisClass == null)
                    return (string)ViewState["GviVAxisClass"];
                else
                    return this.GviVAxisClass.ToString();
            }

            set
            {
                ViewState["GviVAxisClass"] = value;
            }
        }

        [GviLegendOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Legend Postion")]
        public LegendPostion GviLegendPosition
        {
            get
            {
                if (this.GviLegendClass == null)
                    this.GviLegendClass = new Legend();
                return this.GviLegendClass.LegendPosition;
            }

            set
            {
                if (this.GviLegendClass == null)
                    this.GviLegendClass = new Legend();
                this.GviLegendClass.LegendPosition = value;
            }
        }

        [Bindable(false)]
        [Description("Chart Legend")]
        [DataMember(Name = "legend")]
        public Legend GviLegendClass
        {
            get;
            set;
        }

        [GviConfigOption]
        //[GviClass("legend")]
        [Bindable(true)]
        [Category("AjaxExtensions")]
        [Description(@"JSON class for legend")]
        [DefaultValue("")]
        public string GviLengend
        {
            get
            {
                if (this.GviLegendClass == null)
                    return (string)ViewState["GviLegendClass"];
                else
                    return this.GviLegendClass.ToString();

            }

            set
            {
                ViewState["GviLegendClass"] = value;
            }
        }

        [GviConfigOption]
        [GviEventOption("select")]
        [Bindable(true)]
        [Category("Events")]
        [Description("Fired when the user clicks a visual entity. To learn what has been selected, call getSelection().")]
        [DataMember(Name = "select", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnSelect
        {
            get
            {
                string s = (string)ViewState["GviOnSelect"];
                return s;
            }
            set
            {
                ViewState["GviOnSelect"] = value;
            }
        }

        [GviConfigOption]
        [GviEventOption("animationfinish")]
        [Bindable(true)]
        [Category("Events")]
        [Description("Fired when transition animation is complete.")]
        [DataMember(Name = "animationfinish", EmitDefaultValue = true, IsRequired = false)]
        public string GviAnimationFinish
        {
            get
            {
                string s = (string)ViewState["GviAnimationFinish"];
                return s;
            }
            set
            {
                ViewState["GviAnimationFinish"] = value;
            }
        }

        [GviConfigOption]
        [GviEventOption("error")]
        [Bindable(true)]
        [Category("Events")]
        [Description("Fired when an error occurs when attempting to render the chart. (id, message)")]
        [DataMember(Name = "error", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnError
        {
            get
            {
                string s = (string)ViewState["GviOnError"];
                return s;
            }
            set
            {
                ViewState["GviOnError"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("onmouseover")]
        [Bindable(true)]
        [Category("Events")]
        [Description("Fired when the user mouses over a visual entity. Passes back the row and column indices of the corresponding data table element. A bar correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null). (row, column)")]
        [DataMember(Name = "onmouseover", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnMouseover
        {
            get
            {
                string s = (string)ViewState["GviOnMouseover"];
                return s;
            }
            set
            {
                ViewState["GviOnMouseover"] = value;
            }
        }

        [GviConfigOption]
        [GviEventOption("onmouseout")]
        [Bindable(true)]
        [Category("Events")]
        [Description("Fired when the user mouses away from a visual entity. Passes back the row and column indices of the corresponding data table element. A bar correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null). (row, column)")]
        [DataMember(Name = "onmouseout", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnMouseout
        {
            get
            {
                string s = (string)ViewState["GviOnMouseout"];
                return s;
            }
            set
            {
                ViewState["GviOnMouseout"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("ready")]
        [Bindable(true)]
        [Category("Events")]
        [Description("The chart is ready for external method calls. If you want to interact with the chart, and call methods after you draw it, you should set up a listener for this event before you call the draw method, and call them only after the event was fired.")]
        [DataMember(Name = "ready", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnReady
        {
            get
            {
                string s = (string)ViewState["GviOnReady"];
                return s;
            }
            set
            {
                ViewState["GviOnReady"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"An object that specifies the tooltip text style. The object has this format:
            {textStyle: {color: 'black', fontName: Tahoma, fontSize: 10}, showColorCode: true}
            The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.")]
        [DefaultValue("")]
        [DataMember(Name = "tooltip", EmitDefaultValue = true, IsRequired = false)]
        public string GviTooltip
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

       

        protected DataTable dt
        {
            get
            {
                DataTable s = (DataTable)ViewState["GoogleDataTable"];
                return ((s == null) ? new DataTable() : s);
            }

            set
            {
                ViewState["GoogleDataTable"] = value;
            }
        }

        public void ChartData(DataTable dt)
        {
            this.dt = dt;
        }

        public DataTable DataSource 
        {
            get { return this.dt; }
            set { this.dt = value; } 
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;   // create a div instead of a span
                //return base.TagKey;
            }
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.Attributes.Add("id", base.ClientID);       // doing this to support codebehind, results in two id attributes, html seems to handle it okay
            base.AddAttributesToRender(writer);
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("REGISTER_GOOGLE_API_JS"))
                this.Page.ClientScript.RegisterClientScriptInclude("REGISTER_GOOGLE_API_JS", "https://www.google.com/jsapi");

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType().BaseType, "REGISTER_JX_AJAX"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType().BaseType, "REGISTER_JX_AJAX",
                    Resource1.ResourceManager.GetString("jx", System.Globalization.CultureInfo.CurrentCulture), true);
            }

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType().BaseType, "REGISTER_LOCAL_SCRIPTS"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType().BaseType, "REGISTER_LOCAL_SCRIPTS",
                    Resource1.ResourceManager.GetString("SendAndDraw", System.Globalization.CultureInfo.CurrentCulture), true);
            }
        }

        
      



        /*************************************************************************
         * 
         * Support for ASP.NET events
         * 
         ************************************************************************************/
        // Defines a key for storing the delegate for the Click event
        // in the Events list.
        private static readonly object ClickEvent = new object();

        // Defines the Click event using the event property syntax.
        // The Events property stores all the event delegates of
        // a control as name/value pairs. 
        public event EventHandler Click
        {
            // When a user attaches an event handler to the Click event 
            // (Click += myHandler;), the Add method 
            // adds the handler to the 
            // delegate for the Click event (keyed by ClickEvent 
            // in the Events list).
            add
            {
                Events.AddHandler(ClickEvent, value);
            }
            // When a user removes an event handler from the Click event 
            // (Click -= myHandler;), the Remove method 
            // removes the handler from the 
            // delegate for the Click event (keyed by ClickEvent 
            // in the Events list).
            remove
            {
                Events.RemoveHandler(ClickEvent, value);
            }
        }

        // Invokes delegates registered with the Click event.
        //
        protected virtual void OnClick(EventArgs e)
        {
            // Retrieves the event delegate for the Click event
            // from the Events property (which stores
            // the control's event delegates). You must
            // cast the retrieved delegate to the type of your 
            // event delegate.
            EventHandler clickEventDelegate = (EventHandler)Events[ClickEvent];
            if (clickEventDelegate != null)
            {
                clickEventDelegate(this, e);
            }
        }

        // Method of IPostBackEventHandler that raises change events.
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            OnClick(new EventArgs());
        }
        //public void RaisePostBackEvent(string eventArgument)
        //{

        //    OnClick(new EventArgs());
        //}

        // each control must implement this in the concrete 
        //protected override void Render(HtmlTextWriter output)
        //{

        //    output.Write("<INPUT TYPE = submit name = " + this.UniqueID +
        //       " Value = 'Click Me' />");
        //}


        public virtual string PostProcessData(string DATATABLE)
        {
            return DATATABLE;
        }
    }
}
