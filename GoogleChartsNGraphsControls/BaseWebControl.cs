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
    public abstract class BaseWebControl: WebControl, IPostBackEventHandler
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
        [DataMember]
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
        [Description(@"Where to place the chart title, compared to the chart area. Supported values:
            in - Draw the title inside the chart area.
            out - Draw the title outside the chart area.
            none - Omit the title")]
        [DefaultValue("")]
        [DataMember(Name = "titlePosition", IsRequired = false, EmitDefaultValue = true)]
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
       
        [DataMember(Name = "vAxis", EmitDefaultValue = true, IsRequired = false, Order=5)]
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


        //[GviConfigOption]
        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description("Causes charts to throw user-triggered events such as click or mouse over. Supported only for specific chart types. See Events below.")]
        //[DefaultValue(TrippleStateBool.Default)]
        //[DataMember(Name = "enableEvents", EmitDefaultValue = true, IsRequired = false)]
        //public TrippleStateBool GviEnableEvents
        //{
        //    get
        //    {
        //        if (ViewState["GviEnableEvents"] == null) return TrippleStateBool.Default;
        //        TrippleStateBool s = (TrippleStateBool)ViewState["GviEnableEvents"];
        //        return s;
        //    }

        //    set
        //    {
        //        ViewState["GviEnableEvents"] = value;
        //    }
        //}



        //[GviConfigOption]
        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description("If set to false, removes the labels of the categories (the X axis labels).")]
        //[DefaultValue(TrippleStateBool.Default)]
        //[DataMember(Name = "showCategoryLabels", IsRequired = false, EmitDefaultValue = true)]
        //public TrippleStateBool GviShowCategoryLabels
        //{
        //    get
        //    {
        //        if (ViewState["GviShowCategoryLabels"] == null) return TrippleStateBool.Default;
        //        TrippleStateBool s = (TrippleStateBool)ViewState["GviShowCategoryLabels"];
        //        return s;
        //    }

        //    set
        //    {
        //        ViewState["GviShowCategoryLabels"] = value;
        //    }
        //}


        //[GviConfigOption]
        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description("If set to false, removes the labels of the values (the Y axis labels).")]
        //[DefaultValue(TrippleStateBool.Default)]
        //[DataMember(Name = "showValueLabels", IsRequired = false, EmitDefaultValue = true)]
        //public TrippleStateBool GviShowValueLabels
        //{
        //    get
        //    {
        //        if (ViewState["GviShowValueLabels"] == null) return TrippleStateBool.Default;
        //        TrippleStateBool s = (TrippleStateBool)ViewState["GviShowValueLabels"];
        //        return s;
        //    }

        //    set
        //    {
        //        ViewState["GviShowValueLabels"] = value;
        //    }
        //}


        //[GviConfigOption]
        //[Bindable(true)]
        //[Category("GoogleOptions")]
        //[Description("The interval at which to show value axis labels. For example, if min is 0, max is 100, and valueLabelsInterval is 20, the chart will show axis labels at (0, 20, 40, 60, 80 100).")]
        //[DefaultValue(null)]
        //[DataMember(Name = "valueLabelsInterval", IsRequired = false, EmitDefaultValue = true)]
        //public int? GviValueLabelsInterval
        //{
        //    get
        //    {
        //        int? s = (int?)ViewState["GviValueLabelsInterval"];
        //        return s;
        //    }

        //    set
        //    {
        //        ViewState["GviValueLabelsInterval"] = value;
        //    }
        //}



//        [GviEventOption(EventName = "animationfinish")]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Fired when transition animation is complete.")]
//        public string OnEvent_GviAnimationFinish
//        {
//            get
//            {
//                string s = (string)ViewState["OnEvent_GviAnimationFinish"];
//                return s;
//            }
//            set
//            {
//                ViewState["OnEvent_GviAnimationFinish"] = value;
//            }
//        }

//        [GviEventOption(EventName = "error")]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Fired when an error occurs when attempting to render the chart: 
//            Properties: id, message")]
//        public string OnEvent_GviError
//        {
//            get
//            {
//                string s = (string)ViewState["OnEvent_GviError"];
//                return s;
//            }
//            set
//            {
//                ViewState["OnEvent_GviError"] = value;
//            }
//        }


//        [GviEventOption(EventName = "onmouseover")]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Fired when the user mouses over a visual entity. Passes back the row and column indices of the corresponding data table element. A point or annotation correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null).
//            Properties: row, column")]
//        public string OnEvent_GviOnMouseOver
//        {
//            get
//            {
//                string s = (string)ViewState["OnEvent_GviOnMouseOver"];
//                return s;
//            }
//            set
//            {
//                ViewState["OnEvent_GviOnMouseOver"] = value;
//            }
//        }

//        [GviEventOption(EventName = "onmouseout")]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Fired when the user mouses away from a visual entity. Passes back the row and column indices of the corresponding data table element. A point or annotation correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null).
//            Properties: row, column")]
//        public string OnEvent_GviOnMouseOut
//        {
//            get
//            {
//                string s = (string)ViewState["OnEvent_GviOnMouseOut"];
//                return s;
//            }
//            set
//            {
//                ViewState["OnEvent_GviOnMouseOut"] = value;
//            }
//        }



//        [GviEventOption(EventName = "ready")]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"The chart is ready for external method calls. If you want to interact with the chart, and call methods after you draw it, you should set up a listener for this event before you call the draw method, and call them only after the event was fired.")]
//        public string OnEvent_GviReady
//        {
//            get
//            {
//                string s = (string)ViewState["OnEvent_GviReady"];
//                return s;
//            }
//            set
//            {
//                ViewState["OnEvent_GviReady"] = value;
//            }
//        }

//        [GviEventOption(EventName = "select")]
//        [Bindable(true)]
//        [Category("GoogleOptions")]
//        [Description(@"Fired when the user clicks a visual entity. To learn what has been selected, call getSelection().")]
//        public string OnEvent_GviSelect
//        {
//            get
//            {
//                string s = (string)ViewState["OnEvent_GviSelect"];
//                return s;
//            }
//            set
//            {
//                ViewState["OnEvent_GviSelect"] = value;
//            }
//        }

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

        
        //public override string ToString()
        //{
        //    List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
        //    myconverters.Add(new CustomConvertersColorToRGB());
        //    myconverters.Add(new CustomConvertersAxis());
        //    myconverters.Add(new CustomConvertersLegend());
        //    myconverters.Add(new CustomConverterEnum());

        //    Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings()
        //    {
        //         NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        //         Converters = myconverters
        //    };

        //    string s = string.Empty;
        //    s = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, settings);
        //    return s;
        //}



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


        
    }
}
