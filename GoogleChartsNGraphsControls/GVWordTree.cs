using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVWordTree runat=server></{0}:GVWordTree")]
    [ToolboxBitmap(typeof(GVWordTree))]
    [DataContract]
    public class GVWordTree : BaseWebControl
    {

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Draws the chart inside an inline frame. (Note that on IE8, this option is ignored; all IE8 charts are drawn in i-frames.)")]
        [DefaultValue(false)]
        [DataMember(Name = "forceIFrame")]
        public bool? GviForceIFrame
        {
            get
            {
                bool? s = (bool?)ViewState["GviForceIFrame"];
                return s;
            }

            set
            {
                ViewState["GviForceIFrame"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The word tree typeface.")]
        [DefaultValue(null)]
        [DataMember(Name = "forceIFrame")]
        public string GviFontName
        {
            get
            {
                string s = (string)ViewState["GviFontName"];
                return s;
            }

            set
            {
                ViewState["GviFontName"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The upper limit for font size of displayed words.")]
        [DefaultValue(null)]
        [DataMember(Name = "maxFontSize")]
        public int? GviMaxFontSize
        {
            get
            {
                int? s = (int?)ViewState["GviMaxFontSize"];
                return s;
            }

            set
            {
                ViewState["GviMaxFontSize"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The upper limit for font size of displayed words.")]
        [DefaultValue(null)]
        [DataMember(Name = "wordtree")]
        public WordTree GviWordTree
        {
            get;
            set;
        }



     






        public void ChartData(string Value)
        {

            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Value", typeof(String));
            }

            this.dt.Rows.Add(new object[] { Value });
        }
       
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.WORDTREE);
            output.Write(Text);
        }



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
