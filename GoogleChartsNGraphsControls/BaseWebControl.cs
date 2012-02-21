using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Drawing;

namespace GoogleChartsNGraphsControls
{
    [Newtonsoft.Json.JsonObject(Title="options")]

    public abstract class BaseWebControl: WebControl
    {
        public BaseWebControl()
        {
            this.GviAnimationOptions = null;
            this.GVIHAxisClass = null;
        }

        protected BaseGVI gvi = new BaseGVI();

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Newtonsoft.Json.JsonIgnore()]
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
        [Newtonsoft.Json.JsonProperty(PropertyName = "title", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonIgnore()]
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
        [Description(@"Override the GviOptions here by entering your own options JSON.  If this is used then other config options will ignored.")]
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonIgnore()]
        public object GviOptionsOverride
        {
            get
            {
                object s = (object)ViewState["GviOptionsOverride"];
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
        [Newtonsoft.Json.JsonProperty(PropertyName = "backgroundColor", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, TypeNameHandling=Newtonsoft.Json.TypeNameHandling.Objects )]
        [Newtonsoft.Json.JsonConverter(typeof(Color?))]
        [Newtonsoft.Json.JsonIgnore()]
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
        [Description("Use this to assign specific colors to each data series. Colors are specified in the Chart API color format. Color i is used for data column i, wrapping around to the beginning if there are more data columns than colors. If variations of a single color is acceptable for all series, use the color option instead.")]
        [DefaultValue("")]
        [Newtonsoft.Json.JsonProperty(PropertyName = "colors", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonIgnore()]
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
        [Newtonsoft.Json.JsonIgnore()]
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
        [Newtonsoft.Json.JsonIgnore()]
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
        [Newtonsoft.Json.JsonIgnore()]
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
        [GviClass("animation")]
        [Bindable(true)]
        [Category("AjaxExtensions")]
        [Description(@"JSON class for animation of charts")]
        [DefaultValue("")]
        [Newtonsoft.Json.JsonIgnore()]
        public string GviAnimation
        {
            get
            {
                if (this.GviAnimationOptions == null)
                    return (string)ViewState["GviAnimationOptions"];
                else
                    return this.GviAnimationOptions.ToString();
            }

            set
            {
                ViewState["GviAnimationOptions"] = value;
            }
        }

        [Newtonsoft.Json.JsonIgnore()]
        public Animation GviAnimationOptions
        {
            get;
            set;
        }

        [GviAnimationOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The duration of the animation, in milliseconds. For details, see the animation documentation.")]
        [Newtonsoft.Json.JsonIgnore()]
        public int? GviAnimation_Duration
        {
            get
            {
                if (this.GviAnimationOptions == null)
                    this.GviAnimationOptions = new Animation();

                return this.GviAnimationOptions.Duration;
            }

            set
            {
                if (this.GviAnimationOptions == null)
                    this.GviAnimationOptions = new Animation();

                this.GviAnimationOptions.Duration = value;
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
        [Newtonsoft.Json.JsonIgnore()]
        public AnimationEasing GviAnimation_Easing
        {
            get
            {
                if (this.GviAnimationOptions == null)
                    this.GviAnimationOptions = new Animation();

                return this.GviAnimationOptions.Easing;
            }

            set
            {
                if (this.GviAnimationOptions == null)
                    this.GviAnimationOptions = new Animation();

                this.GviAnimationOptions.Easing = value;
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
        [Newtonsoft.Json.JsonIgnore()]
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
        [Newtonsoft.Json.JsonIgnore()]
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

        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"")]
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonIgnore()]
        public string GviFormatHAxis
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

        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"")]
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonIgnore()]
        public string GviFormatVAxis
        {
            get
            {
                if (this.GVIHAxisClass == null)
                    return (string)ViewState["GviViewFormatHook"];
                else
                    return this.GVIHAxisClass.ToString();
            }

            set
            {
                ViewState["GviViewFormatHook"] = value;
            }
        }



        [Bindable(true)]
        [Category("GoogleOptions")]
        [Newtonsoft.Json.JsonIgnore()]
        public hAxis GVIHAxisClass
        {
            get;
            set;
        }

        [GviClass("hAxis")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Configurable Vertical Axis")]
        [Newtonsoft.Json.JsonIgnore()]
        public string GVIHAxis
        {
            get
            {
                if (this.GVIHAxisClass == null)
                    return (string)ViewState["GVIHAxis"];
                else
                    return this.GVIHAxisClass.ToString();
            }

            set
            {
                ViewState["GVIHAxis"] = value;
            }
        }


        [Bindable(true)]
        [Category("GoogleOptions")]
        [Newtonsoft.Json.JsonIgnore()]
        public vAxis GVIVAxisClass
        {
            get;
            set;
        }

        [GviClass("vAxis")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Configurable Vertical Axis")]
        [Newtonsoft.Json.JsonIgnore()]
        public string GVIVAxis
        {
            get
            {
                if (this.GVIVAxisClass == null)
                    return (string)ViewState["GVIVAxis"];
                else
                    return this.GVIVAxisClass.ToString();
            }

            set
            {
                ViewState["GVIVAxis"] = value;
            }
        }

        [Newtonsoft.Json.JsonIgnore()]
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
        [Newtonsoft.Json.JsonIgnore()]
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

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, new CustomConvertersColorToRGB());
        }
    }
}
