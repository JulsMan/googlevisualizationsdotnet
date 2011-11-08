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
                this.Page.ClientScript.RegisterClientScriptInclude("REGISTER_GOOGLE_API_JS", "http://www.google.com/jsapi");

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
    }
}
