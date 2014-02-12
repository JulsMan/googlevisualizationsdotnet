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
    [ToolboxData("<{0}:GVDonutChart runat=server></{0}:GVDonutChart>")]
    [ToolboxBitmap(typeof(GVDonutChart))]
    [DataContract]
    public class GVDonutChart : BaseWebControl
    {
        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"3D chart")]
        [DefaultValue(false)]
        [DataMember(Name="is3d", EmitDefaultValue=true, IsRequired=false)]
        public bool? GviIs3D
        {
            get
            {
                bool? s = (bool?)ViewState["GviIs3D"];
                return s;
            }

            set
            {
                ViewState["GviIs3D"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If between 0 and 1, displays a donut chart. The hole with have a radius equal to number times the radius of the chart.")]
        [DefaultValue(0.4)]
        [DataMember(Name = "pieHole", EmitDefaultValue = true, IsRequired = false)]
        public decimal? GviPieHole 
        {
            get
            {
                decimal? s = (decimal?)ViewState["GviPieHole"];
                return (s == null) ? (decimal?)0.4 : s;

            }
            set
            {
                ViewState["GviPieHole"] = value;
            }
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
           
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.PIECHART);
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
