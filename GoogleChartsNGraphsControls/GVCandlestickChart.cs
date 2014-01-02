using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVCandlestickChart runat=server></{0}:GVCandlestickChart>")]
    [ToolboxBitmap(typeof(GVCandlestickChart))]
    [DataContract]
    public class GVCandlestickChart: BaseWebControl
    {
       

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





    

        protected override void RenderContents(HtmlTextWriter output)
        {

            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.CANDLESTICK);
            output.Write(Text);
        }
        // Support for IPostBackEventHandler
        //protected override void Render(HtmlTextWriter output)
        //{
        //    RenderContents(output);
        //}
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
