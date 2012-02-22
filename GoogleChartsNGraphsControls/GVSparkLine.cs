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
    [ToolboxData("<{0}:GVSparkLine runat=server></{0}:GVSparkLine>")]
    [ToolboxBitmap(typeof(GVSparkLine))]
    [DataContract]
    public class GVSparkLine : BaseWebControl
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
        [Description("If true, will fill the area below the line in color.")]
        [DefaultValue(false)]
        public bool? GviFill
        {
            get
            {
                bool? s = (bool?)ViewState["GviFill"];
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
        [Description(@"The position of the labels. Supported values are 'none', 'left', 'right'.")]
        [DefaultValue("")]
        public string GviLabelPosition
        {
            get
            {
                string s = (string)ViewState["GviLabelPosition"];
                return s;
            }

            set
            {
                ViewState["GviLabelPosition"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The highest value for the data value range of each sparkline. The index in the array must match the column index in the DataTable. If all values are null, this will be the maximum value in the series")]
        [DefaultValue("")]
        public object GviMax
        {
            get
            {
                string s = (string)ViewState["GviMax"];
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
        [Description(@"The lowest value for the data value range of each sparkline. The index in the array must match the column index in the DataTable. If all values are null, this will be minimum value in the series.")]
        [DefaultValue("")]
        public object GviMin
        {
            get
            {
                string s = (string)ViewState["GviMin"];
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
        [Description("If true, axis lines are shown. If false, they are not, and the default for showValueLabels is false.")]
        [DefaultValue(true)]
        public bool? GviShowAxisLines
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowAxisLines"];
                return s;
            }

            set
            {
                ViewState["GviShowAxisLines"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If true, value axis labels are shown.")]
        [DefaultValue(true)]
        public bool? GviShowValueLabels
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowValueLabels"];
                return s;
            }

            set
            {
                ViewState["GviShowValueLabels"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Text to display above the chart.")]
        [DefaultValue("Pie Chart")]
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
        [Description("Vertical or horizontal layout: 'v' for vertical, 'h' for horizontal.")]
        [DefaultValue("v")]
        public string GviLayout
        {
            get
            {
                string s = (string)ViewState["GviLayout"];
                return s;
            }

            set
            {
                ViewState["GviLayout"] = value;
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
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.SPARKLINE);
            output.Write(Text);
        }

    }
}
