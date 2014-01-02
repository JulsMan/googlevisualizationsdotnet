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
    [ToolboxData("<{0}:GVColumnChart runat=server></{0}:GVColumnChart>")]
    [ToolboxBitmap(typeof(GVColumnChart))]
    [DataContract]
    public class GVColumnChart : BaseWebControl
    {

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


        //public void ChartData(string Name, int Value)
        //{

        //    if ((this.dt == null) || (this.dt.Columns.Count == 0))
        //    {
        //        this.dt = new DataTable();
        //        this.dt.Columns.Add("Name", typeof(String));
        //        this.dt.Columns.Add("Value", typeof(decimal));
        //    }

        //    this.dt.Rows.Add(new object[] { Name, (decimal)Value });
        //}
        //public void ChartData(string Name, decimal Value)
        //{
        //    if ((this.dt == null) || (this.dt.Columns.Count == 0))
        //    {
        //        this.dt = new DataTable();
        //        this.dt.Columns.Add("Name", typeof(String));
        //        this.dt.Columns.Add("Value", typeof(decimal));
        //    }

        //    this.dt.Rows.Add(new object[] { Name, Value });
        //}

        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.COLUMNCHART);
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
