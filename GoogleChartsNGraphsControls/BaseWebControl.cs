using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Web.UI;

namespace GoogleChartsNGraphsControls
{
    public class BaseWebControl: WebControl
    {
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
        [Description(@"Override the GviOptions here by entering your own options JSON.  If this is used then other config options will ignored.")]
        [DefaultValue(null)]
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


        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Write a javascript function that inherits 'chart' and registers the events you want...")]
        [DefaultValue(null)]
        public object GviRegisterEvents
        {
            get
            {
                object s = (object)ViewState["GviRegisterEvents"];
                return s;
            }

            set
            {
                ViewState["GviRegisterEvents"] = value;
            }
        }

        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Overrides the name of the element being replaced in the DOM with this chart.")]
        [DefaultValue("")]
        public string OverrideElementId { get; set; }

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
    }
}
