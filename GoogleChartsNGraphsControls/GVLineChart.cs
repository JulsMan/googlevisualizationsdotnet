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
    public class GVLineChart : BaseWebControl, IsStackable, HasTrendLines, HasIntervals
    {
        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Controls the curve of the lines when the line width is not zero. Can be one of the following:
                        'none' - Straight lines without curve.
                        'function' - The angles of the line will be smoothed.")]
        [DefaultValue(CurveType.Function)]
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


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"A trendline is a line superimposed on a chart revealing the overall direction of the data. Google Charts can automatically generate trendlines for Scatter Charts, Bar Charts, Column Charts, and Line Charts.")]
        [DataMember(Name = "intervals", EmitDefaultValue = true, IsRequired = false)]
        public  Interval[] GviIntervals
        {
            get
            {
                Interval[] s = (Interval[])ViewState["GviIntervals"];
                return s;
            }

            set
            {
                Interval[] s = value as Interval[];
                ViewState["GviIntervals"] = s;
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
            myconverters.Add(new CustomConverterTrendLine());
            myconverters.Add(new CustomConverterInterval());

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
                bool? s = value as bool?;
                ViewState["GviIsStacked"] = s;
            }
        }


    }
}
