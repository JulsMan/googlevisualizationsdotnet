using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Data;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVPieChart runat=server></{0}:GVPieChart>")]
    [ToolboxBitmap(typeof(GVPieChart))]
    [DataContract]
    public class GVPieChart : BaseWebControl
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
        [Description("Specifies a base color to use for all series; each series will be a gradation of the color specified. Colors are specified in the Chart API color format. Ignored if colors is specified.")]
        [DefaultValue("")]
        public Color? GviColor
        {
            get
            {
                Color? s = (Color?)ViewState["GviColor"];
                return s;
            }

            set
            {
                ViewState["GviColor"] = value;
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
        [Description("Causes charts to throw user-triggered events such as click or mouse over. Supported only for specific chart types. See Events below.")]
        [DefaultValue(false)]
        public bool? GviEnableEvents
        {
            get
            {
                bool? s = (bool?)ViewState["GviEnableEvents"];
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
        [Description("If set to true, displays a three-dimensional chart.")]
        [DefaultValue(false)]
        public bool? GviIs3D
        {
            get
            {
                bool? s = (bool?)ViewState["GviIs3D"];
                return s;
            }

            set
            {
                ViewState["GviIs3D"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"What label, if any, to show for each slice. Choose from the following values:
            'none' - No labels.
            'value' - Use the slice value as a label.
            'name' - Use the slice name (the column name).")]
        [DefaultValue("")]
        public string GviLabels
        {
            get
            {
                string s = (string)ViewState["GviLabels"];
                return s;
            }

            set
            {
                ViewState["GviLabels"] = value;
            }
        }


        [GviEventOption(EventName = "animationfinish")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when transition animation is complete.")]
        public string OnEvent_GviAnimationFinish
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviAnimationFinish"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviAnimationFinish"] = value;
            }
        }

        [GviEventOption(EventName = "error")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when an error occurs when attempting to render the chart: 
            Properties: id, message")]
        public string OnEvent_GviError
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviError"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviError"] = value;
            }
        }

        [GviEventOption(EventName = "onmouseover")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when the user mouses over a visual entity. Passes back the row and column indices of the corresponding data table element. A point or annotation correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null).
            Properties: row, column")]
        public string OnEvent_GviOnMouseOver
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviOnMouseOver"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviOnMouseOver"] = value;
            }
        }

        [GviEventOption(EventName = "onmouseout")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when the user mouses away from a visual entity. Passes back the row and column indices of the corresponding data table element. A point or annotation correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null).
            Properties: row, column")]
        public string OnEvent_GviOnMouseOut
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviOnMouseOut"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviOnMouseOut"] = value;
            }
        }

        [GviEventOption(EventName = "ready")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The chart is ready for external method calls. If you want to interact with the chart, and call methods after you draw it, you should set up a listener for this event before you call the draw method, and call them only after the event was fired.")]
        public string OnEvent_GviReady
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviReady"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviReady"] = value;
            }
        }

        [GviEventOption(EventName = "select")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when the user clicks a visual entity. To learn what has been selected, call getSelection().")]
        public string OnEvent_GviSelect
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviSelect"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviSelect"] = value;
            }
        }

        public void ChartData(string Name, int Value)
        {
           
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(String));
                this.dt.Columns.Add("Value", typeof(decimal));
            }

            this.dt.Rows.Add(new object[] { Name, (decimal) Value });
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
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.PIECHART);
            output.Write(Text);
        }

        public override string ToString()
        {
            List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
            myconverters.Add(new CustomConvertersColorToRGB());
            myconverters.Add(new CustomConvertersAxis());
            myconverters.Add(new CustomConvertersLegend());
            myconverters.Add(new CustomConverterEnum());

            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                Converters = myconverters
            };

            string s = string.Empty;
            s = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, settings);
            return s;
        }

    }
}
