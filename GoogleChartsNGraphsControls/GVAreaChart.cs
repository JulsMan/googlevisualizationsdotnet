using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVAreaChart runat=server></{0}:GVAreaChart>")]
    [ToolboxBitmap(typeof(GVAreaChart))]
    [DataContract]
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
