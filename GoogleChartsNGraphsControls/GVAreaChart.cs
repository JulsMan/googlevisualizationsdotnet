using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVAreaChart runat=server></{0}:GVAreaChart>")]
    [ToolboxBitmap(typeof(GVAreaChart))]
    public class GVAreaChart : BaseWebControl
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
        [Description("The maximal value to show in the Y axis.")]
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
        [Description("The minimal value to show in the Y axis.")]
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
        [Description("If set to false, removes the labels of the categories (the X axis labels).")]
        [DefaultValue(true)]
        public bool? GviShowCategoryLabels
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowCategoryLabels"];
                return s;
            }

            set
            {
                ViewState["GviShowCategoryLabels"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If set to false, removes the labels of the values (the Y axis labels).")]
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
        [Description("The interval at which to show value axis labels. For example, if min is 0, max is 100, and valueLabelsInterval is 20, the chart will show axis labels at (0, 20, 40, 60, 80 100).")]
        [DefaultValue(null)]
        public int? GviValueLabelsInterval
        {
            get
            {
                int? s = (int?)ViewState["GviValueLabelsInterval"];
                return s;
            }

            set
            {
                ViewState["GviValueLabelsInterval"] = value;
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
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.AREACHART);
            output.Write(Text);
        }
    }
}
