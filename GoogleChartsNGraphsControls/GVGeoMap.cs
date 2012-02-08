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

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVGeoMap runat=server></{0}:GVGeoMap>")]
    [ToolboxBitmap(typeof(GVGeoMap))]
    public class GVGeoMap : BaseWebControl
    {

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The area to display on the map. (Surrounding areas will be displayed as well.) Can be either a country code (in uppercase ISO-3166 format), or a one of the following strings:
            world - (Whole world)
            us_metro - (United States, metro areas)
            005 - (South America)
            013 - (Central America)
            021 - (North America)
            002 - (All of Africa)
            017 - (Central Africa)
            015 - (Northern Africa)
            018 - (Southern Africa)
            030 - (Eastern Asia)
            034 - (Southern Asia)
            035 - (Asia/Pacific region)
            143 - (Central Asia)
            145 - (Middle East)
            151 - (Northern Asia)
            154 - (Northern Europe)
            155 - (Western Europe)
            039 - (Southern Europe)
            Geomap does not enable scrolling or dragging behavior, and only limited zooming behavior. A basic zoom out can be enabled by setting the showZoomOut property.")]
        [DefaultValue("world")]
        public MapRegion GviRegion
        {
            get
            {
                object s = ViewState["GviRegion"];
                return s == null ? MapRegion.World: (MapRegion)s;
            }

            set
            {
                ViewState["GviRegion"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"How to display values on the map. Two values are supported:
            regions - Colors a whole region with the appropriate color. This option cannot be used with latitude/longitude addresses. See Regions Example.
            markers - Displays a dot over a region, with the color and size indicating the value. See Markers Example.")]
        public MapDisplayModes GviDisplayMode
        {
            get
            {
                object s = ViewState["GviDisplayMode"];
                return s != null ? (MapDisplayModes)s : MapDisplayModes.Auto;
            }

            set
            {
                ViewState["GviDisplayMode"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The resolution of the map borders. Choose one of the following values:
            'countries' - Supported for all regions, except for US state regions.
            'provinces' - Supported only for country regions and US state regions. Not supported for all countries; please test a country to see whether this option is supported.
            'metros' - Supported for the US country region and US state regions only.")]
        public MapResolution GviResolution
        {
            get
            {
                object s = ViewState["GviResolution"];
                return s != null ? (MapResolution)s : MapResolution.Countries;
            }

            set
            {
                ViewState["GviResolution"] = value;
            }
        }

        [GviConfigOption]
        [TypeConverter(typeof(WebColorConverter))]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Color gradient to assign to values in the visualization. You must have at least two values; the gradient will include all your values, plus calculated intermediary values, with the lightest color as the smallest value, and the darkest color as the highest.")]
        [DefaultValue("")]
        public Color?[] GviColors
        {
            get
            {
                Color?[] s = (Color?[])ViewState["GviColors"];
                return s;
            }

            set
            {
                ViewState["GviColors"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If true, display a legend for the map.")]
        [DefaultValue("hybrid")]
        public bool? GviShowLegend
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowLegend"];
                return s;
            }

            set
            {
                ViewState["GviShowLegend"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description("If true, display a button with the label specified by the zoomOutLabel property. Note that this button does nothing when clicked, except throw the zoomOut event. To handle zooming, catch this event and change the region option. You can only specify showZoomOut if the region option is smaller than the world view. One way of enabling zoom in behavior would be to listen for the regionClick event, change the region property to the appropriate region, and reload the map.")]
        [Category("GoogleOptions")]
        [DefaultValue(false)]
        public bool? GviShowZoomOut
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowZoomOut"];
                return ((s == null) ? false : s);
            }

            set
            {
                ViewState["GviShowZoomOut"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Description("Label for the zoom button.")]
        [Category("GoogleOptions")]
        [DefaultValue("Zoom Out")]
        public string GviZoomOutLabel
        {
            get
            {
                string s = (string)ViewState["GviZoomOutLabel"];
                return s;
            }

            set
            {
                ViewState["GviZoomOutLabel"] = value;
            }
        }

        [GviEventOption(EventName = "error")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when an error occurs when attempting to render the chart: 
            Properties: id, message")]
        public string OnEvent_GviError
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviError"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviError"] = value;
            }
        }

        [GviEventOption(EventName = "regionClick")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Called when a region is clicked. This will not be thrown for the specific country assigned in the 'region' option (if a specific country was listed).
            An object with a single property, region, that is a string in ISO-3166 format describing the region clicked.")]
        public string OnEvent_GviOnRegionClick
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviOnRegionClick"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviOnRegionClick"] = value;
            }
        }

        [GviEventOption(EventName = "ready")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The chart is ready for external method calls. If you want to interact with the chart, and call methods after you draw it, you should set up a listener for this event before you call the draw method, and call them only after the event was fired.")]
        public string OnEvent_GviReady
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviReady"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviReady"] = value;
            }
        }

        [GviEventOption(EventName = "select")]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Fired when the user clicks a visual entity. To learn what has been selected, call getSelection().")]
        public string OnEvent_GviSelect
        {
            get
            {
                string s = (string)ViewState["OnEvent_GviSelect"];
                return s;
            }
            set
            {
                ViewState["OnEvent_GviSelect"] = value;
            }
        }


        protected override void RenderContents(HtmlTextWriter output)
        {
            
            //gvi.RegisterGVIScripts(this, this.JsonData, BaseGVI.GOOGLECHART.MAP);
            //this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            
            // A datatable is required for this object ...
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                
                this.dt = new DataTable("World Map");
                this.dt.Columns.Add(new DataColumn("Country", typeof(string)));
                this.dt.Rows.Add(new object[] {"USA" });
            }
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.GEOMAP);
            output.Write(String.Empty);
        }
    }
}
