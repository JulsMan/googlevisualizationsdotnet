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
        [DefaultValue("regions")]
        public string GviRegion
        {
            get
            {
                string s = (string)ViewState["GviRegion"];
                return s;
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
        [DefaultValue("regions")]
        public string GviDataMode
        {
            get
            {
                string s = (string)ViewState["GviDataMode"];
                return s;
            }

            set
            {
                ViewState["GviDataMode"] = value;
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



        protected override void RenderContents(HtmlTextWriter output)
        {
            
            //gvi.RegisterGVIScripts(this, this.JsonData, BaseGVI.GOOGLECHART.MAP);
            //this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.GEOMAP);
            output.Write(String.Empty);
        }
    }
}
