using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVMap runat=server></{0}:GVMap>")]
    [ToolboxBitmap(typeof(GVMap))]
    [DataContract]
    public class GVMap : BaseWebControl
    {

       

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Which type of map this is. The DataTable format must match the value specified. The following values are supported:
            'auto' - Choose based on the format of the DataTable.
            'regions' - This is a region map
            'markers' - This is a marker map.")]
        [DefaultValue("displayMode")]
        [DataMember(Name = "displayMode", EmitDefaultValue=true, IsRequired=false)]
        public MapDisplayModes GviDisplayMode
        {
            get
            {
                MapDisplayModes? s = (MapDisplayModes?)ViewState["GviDisplayMode"];
                return s == null ? MapDisplayModes.Default : (MapDisplayModes)s;
            }

            set
            {
                ViewState["GviDisplayMode"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description(@"The area to display on the map. (Surrounding areas will be displayed as well.) Can be one of the following:
'world' - A map of the entire world.
A continent or a sub-continent, specified by its 3-digit code, e.g., '011' for Western Africa.
A country, specified by its ISO 3166-1 alpha-2 code, e.g., 'AU' for Australia.
A state in the United States, specified by its ISO 3166-2:US code, e.g., 'US-AL' for Alabama. Note that the resolution option must be set to either 'provinces' or 'metros'.")]
        [Category("GoogleOptions")]
        [DefaultValue(false)]
        [DataMember(Name = "region", EmitDefaultValue = true, IsRequired = false)]
        public MapRegion GviRegion
        {
            get
            {
                MapRegion? s = (MapRegion?)ViewState["GviRegion"];
                return s == null ? MapRegion.Default : (MapRegion)s;
            }

            set
            {
                ViewState["GviRegion"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The resolution of the map borders. Choose one of the following values:
                        'countries' - Supported for all regions, except for US state regions.
                        'provinces' - Supported only for country regions and US state regions. 
                            Not supported for all countries; please test a country to see whether this option is supported.
                        'metros' - Supported for the US country region and US state regions only.")]
        [DefaultValue("displayMode")]
        [DataMember(Name = "resolution", EmitDefaultValue = true, IsRequired = false)]
        public MapResolution GviResolution
        {
            get
            {
                MapResolution? s = (MapResolution?)ViewState["GviResolution"];
                return s == null ? MapResolution.Default : (MapResolution)s;
            }

            set
            {
                ViewState["GviResolution"] = value;
            }
        }



        public void ChartData(string Address, string LocationName)
        {
           
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add(new DataColumn("Address", typeof(String)));
                this.dt.Columns.Add(new DataColumn("Name", typeof(String)));
            }

            this.dt.Rows.Add(new object[] { Address, LocationName });
            // this.JsonData = gvi.googleDataTableToJson(dt);
        }
        public void ChartData(string LocationName, string Street, string City, string State)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Address", typeof(String));
                this.dt.Columns.Add("Name", typeof(String));
            }

            this.dt.Rows.Add(new object[] { string.Format("{0} {1} {2}",Street, City, State), LocationName });
            //this.JsonData = gvi.googleDataTableToJson(dt);

        }
        public void ChartData(string LocationName, MapCoordinate LonLatPoint)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Lat", typeof(decimal));
                this.dt.Columns.Add("Lon", typeof(decimal));
                this.dt.Columns.Add("Name", typeof(String));
            }

            this.dt.Rows.Add(new object[] { LonLatPoint.Lat, LonLatPoint.Lon, LocationName });
            //this.JsonData = gvi.googleDataTableToJson(dt);
        }
        public void ChartData(string LocationName, Decimal LatituePoint, Decimal LongitudePoint)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Lat", typeof(decimal));
                this.dt.Columns.Add("Lon", typeof(decimal));
                this.dt.Columns.Add("Name", typeof(String));
            }

            this.dt.Rows.Add(new object[] { LatituePoint, LongitudePoint, LocationName });
            //this.JsonData = gvi.googleDataTableToJson(dt);
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            
            //gvi.RegisterGVIScripts(this, this.JsonData, BaseGVI.GOOGLECHART.MAP);
            //this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.MAP);
            output.Write(String.Empty);
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
