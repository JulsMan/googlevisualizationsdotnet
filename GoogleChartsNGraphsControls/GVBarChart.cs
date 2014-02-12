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
    [ToolboxData("<{0}:GVBarChart runat=server></{0}:GVBarChart>")]
    [ToolboxBitmap(typeof(GVBarChart))]
    [DataContract]
    public class GVBarChart : BaseWebControl, IsStackable, HasTrendLines
    {

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, bar values are stacked (accumulated).")]
        [DefaultValue(false)]
        [DataMember(Name="isStacked", EmitDefaultValue=true, IsRequired = false)]
        public bool? GviIsStacked
        {
            get
            {
                bool? s = (bool?)ViewState["GviIsStacked"];
                return s;
            }

            set
            {
                bool? s = value as bool?;
                ViewState["GviIsStacked"] = s;
            }
        }

      
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.BARCHART);
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


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"A trendline is a line superimposed on a chart revealing the overall direction of the data. Google Charts can automatically generate trendlines for Scatter Charts, Bar Charts, Column Charts, and Line Charts.")]
        [DataMember(Name = "trendlines", EmitDefaultValue = true, IsRequired = false)]
        public TrendLine[] GviTrendLine
        {
            get
            {
                TrendLine[] s = (TrendLine[])ViewState["GviTrendLine"];
                return s;
            }

            set
            {
                TrendLine[] s = value as TrendLine[];
                ViewState["GviTrendLine"] = s;
            }
        }
    }
}
