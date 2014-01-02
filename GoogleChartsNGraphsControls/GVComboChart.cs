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
    [ToolboxData("<{0}:GVComboChart runat=server></{0}:GVComboChart>")]
    [ToolboxBitmap(typeof(GVComboChart))]
    [DataContract]
    public class GVComboChart : BaseWebControl, IsStackable
    {

        public GVComboChart()
            : base()
        {
            this.GviSeriesType = SeriesType.Bars;
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, bar values are stacked (accumulated).")]
        [DefaultValue(false)]
        [DataMember(Name = "isStacked", EmitDefaultValue = true, IsRequired = false)]
        public bool? GviIsStacked
        {
            get
            {
                bool? s = (bool?)ViewState["GviIsStacked"];
                return s;
            }

            set
            {
                ViewState["GviIsStacked"] = value;
            }
        }




        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The default line type for any series not specified in the series property. 
            Available values are 'line', 'area', 'bars', 'candlesticks' and 'steppedArea'.")]
        [DataMember(Name = "seriesType", EmitDefaultValue = false, IsRequired = true)]
        [DefaultValue(SeriesType.Bars)]
        public SeriesType GviSeriesType
        {
            get
            {
                object s = ViewState["GviSeriesType"];
                if (s == null) return SeriesType.Bars;
                SeriesType ss = (SeriesType)ViewState["GviSeriesType"];
                return ss;
            }
            set
            {
                ViewState["GviSeriesType"] = value;
            }
        }



       
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;

            // combocharts need to have an Average column or an average column specified to show the average line


            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.COMBO);
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
