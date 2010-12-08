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

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVGauge runat=server></{0}:GVGauge>")]
    [ToolboxBitmap(typeof(GVGauge))]
    public class GVGauge : BaseWebControl
    {
        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The lowest value for a range marked by a green color.")]
        [DefaultValue(null)]
        public int? GviGreenFrom
        {
            get
            {
                int? s = (int?)ViewState["GviGreenFrom"];
                return s;
            }

            set
            {
                ViewState["GviGreenFrom"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The highest value for a range marked by a green color.")]
        [DefaultValue(null)]
        public int? GviGreenTo
        {
            get
            {
                int? s = (int?)ViewState["GviGreenTo"];
                return s;
            }

            set
            {
                ViewState["GviGreenTo"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Labels for major tick marks. The number of labels define the number of major ticks in all gauges. The default is five major ticks, with the labels of the minimal and maximal gauge value.")]
        [DefaultValue(null)]
        public object GviMajorTicks
        {
            get
            {
                object s = (object)ViewState["GviMajorTicks"];
                return s;
            }

            set
            {
                ViewState["GviMajorTicks"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The maximal value of a gauge.")]
        [DefaultValue(100)]
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
        [Description("The minimal value of a gauge.")]
        [DefaultValue(0)]
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
        [Description("The number of minor tick section in each major tick section.")]
        [DefaultValue(0)]
        public int? GviMinorTicks
        {
            get
            {
                int? s = (int?)ViewState["GviMinorTicks"];
                return s;
            }

            set
            {
                ViewState["GviMinorTicks"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The lowest value for a range marked by a red color.")]
        [DefaultValue(0)]
        public int? GviRedFrom
        {
            get
            {
                int? s = (int?)ViewState["GviRedFrom"];
                return s;
            }

            set
            {
                ViewState["GviRedFrom"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The highest value for a range marked by a red color.")]
        [DefaultValue(0)]
        public int? GviRedTo
        {
            get
            {
                int? s = (int?)ViewState["GviRedTo"];
                return s;
            }

            set
            {
                ViewState["GviRedTo"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The lowest value for a range marked by a yellow color.")]
        [DefaultValue(0)]
        public int? GviYellowFrom
        {
            get
            {
                int? s = (int?)ViewState["GviYellowFrom"];
                return s;
            }

            set
            {
                ViewState["GviYellowFrom"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The highest value for a range marked by a yellow color.")]
        [DefaultValue(0)]
        public int? GviYellowTo
        {
            get
            {
                int? s = (int?)ViewState["GviYellowTo"];
                return s;
            }

            set
            {
                ViewState["GviYellowTo"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.GAUGE);
            output.Write(String.Empty);
        }

    }
}
