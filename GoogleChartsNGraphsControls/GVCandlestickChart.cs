using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVCandlestickChart runat=server></{0}:GVCandlestickChart>")]
    [ToolboxBitmap(typeof(GVCandlestickChart))]
    public class GVCandlestickChart: BaseWebControl
    {


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The background color for the chart.")]
        [DefaultValue(Position.Out)]
        public Position GVIAxisTitlesPosition
        {
            get
            {
                object s = ViewState["GVIAxisTitlesPosition"];
                if (s == null) return Position.Out;
                Position ss = (Position)ViewState["GVIAxisTitlesPosition"];
                return ss;
            }

            set
            {
                ViewState["GVIAxisTitlesPosition"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Whether the chart throws user-based events or reacts to user interaction. If false, the chart will not throw 'select' or other interaction-based events (but will throw ready or error events), and will not display hovertext or otherwise change depending on user input.")]
        [DefaultValue(true)]
        public bool? GVIEnableInteractivity
        {
            get
            {
                return (bool?) ViewState["GVIEnableInteractivity"];
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
        [Description("If set to true, will draw series from right to left. The default is to draw left-to-right.")]
        [DefaultValue(false)]
        public bool? GVIReverseCategories
        {
            get
            {
                return (bool?)ViewState["GVIReverseCategories"];
            }
            set
            {
                ViewState["GVIReverseCategories"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Where to place the chart title, compared to the chart area. Supported values:
            in - Draw the title inside the chart area.
            out - Draw the title outside the chart area.
            none - Omit the title.")]
        [DefaultValue(CandlestickTheme.Default)]
        public CandlestickTheme GVITheme
        {
            get
            {
                object s = ViewState["GVITheme"];
                if (s == null) return CandlestickTheme.Default;
                CandlestickTheme ss = (CandlestickTheme)ViewState["GVITheme"];
                return ss;
            }
            set
            {
                ViewState["GVITheme"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"A theme is a set of predefined option values that work together to achieve a specific chart behavior or visual effect. Currently only one theme is available:
            'maximized' - Maximizes the area of the chart, and draws the legend and all of the labels inside the chart area. Sets the following options:")]
        [DefaultValue(TitlePosition.Out)]
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


    

        protected override void RenderContents(HtmlTextWriter output)
        {

            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.CANDLESTICK);
            output.Write(Text);
        }
    }
}
