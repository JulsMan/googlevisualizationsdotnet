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
    [ToolboxData("<{0}:GVMotionChart runat=server></{0}:GVMotionChart>")]
    [ToolboxBitmap(typeof(GVMotionChart))]
    [DataContract]
    public class GVMotionChart : BaseWebControl
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
        [Description(@"An initial display state for the chart. This is a serialized JSON object that describes zoom level, selected dimensions, selected bubbles/entities, and other state descriptions. See Setting Initial State to learn how to set this.")]
        [DefaultValue("")]
        public string GviState
        {
            get
            {
                string s = (string)ViewState["GviState"];
                return s;
            }

            set
            {
                ViewState["GviState"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the buttons that control the chart type (bubbles / lines / columns) at top right corner.")]
        [DefaultValue(true)]
        public bool? GviShowChartButtons
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowChartButtons"];
                return s;
            }

            set
            {
                ViewState["GviShowChartButtons"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the title label of the entities (derived from the label of the first column in the data table).")]
        [DefaultValue(true)]
        public bool? GviShowHeader
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowHeader"];
                return s;
            }

            set
            {
                ViewState["GviShowHeader"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the list of visible entities.")]
        [DefaultValue(true)]
        public bool? GviShowSelectListComponent
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowSelectListComponent"];
                return s;
            }

            set
            {
                ViewState["GviShowSelectListComponent"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the right hand panel.")]
        [DefaultValue(true)]
        public bool? GviShowSidePanel
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowSidePanel"];
                return s;
            }

            set
            {
                ViewState["GviShowSidePanel"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the metric picker for x.")]
        [DefaultValue(true)]
        public bool? GviShowXMetricPicker
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowXMetricPicker"];
                return s;
            }

            set
            {
                ViewState["GviShowXMetricPicker"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the metric picker for y.")]
        [DefaultValue(true)]
        public bool? GviShowYMetricPicker
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowYMetricPicker"];
                return s;
            }

            set
            {
                ViewState["GviShowYMetricPicker"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the scale picker for x.")]
        [DefaultValue(true)]
        public bool? GviShowXScalePicker
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowXScalePicker"];
                return s;
            }

            set
            {
                ViewState["GviShowXScalePicker"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false hides the scale picker for y.")]
        [DefaultValue(true)]
        public bool? GviShowYScalePicker
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowYScalePicker"];
                return s;
            }

            set
            {
                ViewState["GviShowYScalePicker"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"false disables the options compartment in the settings panel.")]
        [DefaultValue(true)]
        public bool? GviShowAdvancedPanel
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowAdvancedPanel"];
                return s;
            }

            set
            {
                ViewState["GviShowAdvancedPanel"] = value;
            }
        }


        public void ChartData(DataTable dt)
        {
            this.dt = dt;   
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            
            // this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.MOTIONCHART);
            output.Write(Text);
        }

    }
}
