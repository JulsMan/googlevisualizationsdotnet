using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;
using System.Data;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVLineChart runat=server></{0}:GVLineChart>")]
    [ToolboxBitmap(typeof(GVLineChart))]
    [DataContract]
    public class GVLineChart : BaseWebControl
    {
        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Controls the curve of the lines when the line width is not zero. Can be one of the following:
                        'none' - Straight lines without curve.
                        'function' - The angles of the line will be smoothed.")]
        [DefaultValue(CurveType.None)]
        [DataMember(Name = "curveType", EmitDefaultValue = true, IsRequired = false)]
        public CurveType GviCurveType
        {
            get
            {
                object s = ViewState["GviCurveType"];
                if (s == null) return CurveType.None;
                CurveType ss = (CurveType)ViewState["GviCurveType"];
                return ss;
            }
            set
            {
                ViewState["GviCurveType"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.LINECHART);
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
