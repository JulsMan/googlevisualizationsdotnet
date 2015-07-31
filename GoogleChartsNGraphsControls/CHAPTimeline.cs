using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:CHAPTimeline runat=server></{0}:CHAPTimeline>")]
    [ToolboxBitmap(typeof(CHAPTimeline))]
    [DataContract]
    public class CHAPTimeline : BaseWebControl
    {
        private DateTime? visibleChartRangeStart
        {
            get
            {
                if (ViewState["visibleChartRangeStart"] == null)
                    return null;

                DateTime? s = (DateTime?)ViewState["visibleChartRangeStart"];
                return s;
            }
            set
            {
                ViewState["visibleChartRangeStart"] = value;
            }
        }
        private DateTime? visibleChartRangeEnd
        {
            get
            {
                if (ViewState["visibleChartRangeEnd"] == null)
                    return null;

                DateTime? s = (DateTime?)ViewState["visibleChartRangeEnd"];
                return s;
            }
            set
            {
                ViewState["visibleChartRangeEnd"] = value;
            }
        }

        public void SetVisibleChartRange(DateTime start, DateTime end)
        {
            this.visibleChartRangeStart = start;
            this.visibleChartRangeEnd = end;
        }
        public void ChartData(CHAPTimelineEvent[] ListOfEvents)
        {

            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                // there always must be a date
                dt.Columns.Add("start", typeof(DateTime));
                dt.Columns.Add("end", typeof(DateTime));
                dt.Columns.Add("content");
            }


            foreach(var ee in ListOfEvents)
            {
                this.dt.Rows.Add(ee.ToRow());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType().BaseType, "REGISTER_CHAP_TIMELINE"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType().BaseType, "REGISTER_CHAP_TIMELINE",
                    Resource1.ResourceManager.GetString("timeline_min", System.Globalization.CultureInfo.CurrentCulture), true);
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType().BaseType, "REGISTER_CHAP_TIMELINE_LOCALES",
                   Resource1.ResourceManager.GetString("timeline_locales", System.Globalization.CultureInfo.CurrentCulture), true);

                 
                 this.Page.Header.Controls.Add(new LiteralControl("<style type=\"text/css\">" 
                     + Environment.NewLine 
                     + Resource1.ResourceManager.GetString("timeline", System.Globalization.CultureInfo.CurrentCulture) 
                     + Environment.NewLine + "</style>" ));


                this.Page.Header.Controls.Add(new LiteralControl("<style type=\"text/css\">"
                    + Environment.NewLine
                    + Resource1.ResourceManager.GetString("timeline_theme", System.Globalization.CultureInfo.CurrentCulture)
                    + Environment.NewLine + "</style>"));

            }

          
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.CHAP_TIMELINE);
            output.Write(Text);
        }

        public override string ToString()
        {
            List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
            myconverters.Add(new CustomConvertersColorToRGB());
            myconverters.Add(new CustomConvertersAxis());
            myconverters.Add(new CustomConvertersLegend());
            myconverters.Add(new CustomConverterEnum());
            myconverters.Add(new CustomConverterTrendLine());

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
