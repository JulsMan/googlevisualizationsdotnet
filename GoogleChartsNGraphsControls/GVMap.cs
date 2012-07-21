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
        [Description("If set to true, enables zooming in and out using the mouse scroll wheel.")]
        [Category("GoogleOptions")]
        [DefaultValue(false)]
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        public bool? GviEnableScrollWheel
        {
            get
            {
                bool? s = (bool?)ViewState["GviEnableScrollWheel"];
                return (s == null ? false : s);
            }

            set
            {
                ViewState["GviEnableScrollWheel"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description("If set to true, shows the location description as a tooltip when the mouse is positioned above a point marker.")]
        [Category("GoogleOptions")]
        [DefaultValue(false)]
        public bool? GviShowTip
        {
            get
            {
                bool? s = (bool?)ViewState["ShowTip"];
                return (s==null?false:s);
            }

            set
            {
                ViewState["ShowTip"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If set to true, shows a Google Maps polyline through all the points.")]
        [DefaultValue(false)]
        public bool? GviShowLine
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowLine"];
                return (s == null ? false : s);
            }

            set
            {
                ViewState["GviShowLine"] = value;
            }
        }

        [GviConfigOption]
        [TypeConverter(typeof(WebColorConverter))]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If showLine is true, defines the line color. For example: '#800000'.")]
        [DefaultValue("")]
        public Color? GviLineColor
        {
            get
            {
                Color? s = (Color?)ViewState["GviLineColor"];
                return s;
            }

            set
            {
                ViewState["GviLineColor"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If showLine is true, defines the line width (in pixels).")]
        [DefaultValue(10)]
        public int? GviLineWidth
        {
            get
            {
                int? s = (int?)ViewState["GviLineWidth"];
                return s;
            }

            set
            {
                ViewState["GviLineWidth"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The type of map to show. Possible values are 'normal', 'terrain', 'satellite' or 'hybrid'.")]
        [DefaultValue("hybrid")]
        public string GviMapType
        {
            get
            {
                string s = (string)ViewState["MapType"];
                return s;
            }

            set
            {
                ViewState["MapType"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description("Show a map type selector that enables the viewer to switch between [map, satellite, hybrid, terrain]. When useMapTypeControl is false (default) no selector is presented and the type is determined by the mapType option.")]
        [Category("GoogleOptions")]
        [DefaultValue(false)]
        public bool? GviUseMapTypeControl
        {
            get
            {
                bool? s = (bool?)ViewState["UseMapTypeControl"];
                return ((s == null) ? false : s);
            }

            set
            {
                ViewState["UseMapTypeControl"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description("An integer indicating the initial zoom level of the map, where 0 is completely zoomed out (whole world) and 19 is the maximum zoom level. (See 'Zoom Levels' in the Google Maps API.)")]
        [Category("GoogleOptions")]
        [DefaultValue(4)]
        public int? GviZoomLevel
        {
            get
            {
                int? s = (int?)ViewState["UseMapTypeControl"];
                return s;
            }

            set
            {
                ViewState["UseMapTypeControl"] = value;
            }
        }


        //protected DataTable dt
        //{
        //    get
        //    {
        //        DataTable s = (DataTable)ViewState["GoogleDataTable"];
        //        return ((s == null) ? new DataTable() : s);
        //    }

        //    set
        //    {
        //        ViewState["GoogleDataTable"] = value;
        //    }
        //}

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
