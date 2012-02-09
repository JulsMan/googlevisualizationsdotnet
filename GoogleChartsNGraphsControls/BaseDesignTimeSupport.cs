using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace GoogleChartsNGraphsControls
{
    public enum TrippleStateBool { True, False, NotSet}
    public enum TitlePosition { In, Out, None}
    public enum Legend { Right, Top, Bottom, None}
    public enum HighlightDot { Nearest, Last}
    public enum WindowMode { Window, Opaque, Transparent }
    public enum ScaleType {Fixed, Maximized, AllMaximaized, AllFixed }
    public enum LegendPosition { SameRow, NewRow }
    public enum PieSliceText { Percentage, Value, Label, None }
    public enum MapRegion 
    { 
        World, US_Metro, South_America, Central_America, North_America, 
        Africa, Central_Africa, Northern_Africa, Southern_Africa, 
        Eastern_Asia, Southern_Asia, AsiaPacific, Central_Asia,
        Middle_East, Northern_Asia, 
        Northern_Europe, Western_Europe, Southern_Europe
    }
    public enum MapDisplayModes { Auto, Regions,Markers }
    public enum MapResolution { Countries, Provinces, Metros }
    public enum OrgChartSize { Small, Medium, Large }
    public enum CurveType { None, Function }
    public enum WindowsMode { }
    public enum AnimationEasing { None,Linear, In, Out, InAndOut }
    public enum AxisTitlesPosition { None, In, Out}
    public enum FocusTarget { None, Datrum, Category}
    public enum CandlestickTheme { None, Maximized }

    public static class BaseDesignTimeSupport
    {
        public static string Parse(this TrippleStateBool state)
        {
            switch (state)
            {
                case TrippleStateBool.False:
                    return "false";
                case TrippleStateBool.True:
                    return "true";
                default:
                    return "";
            }
        }
        public static string Parse(this MapRegion state)
        {
            switch (state)
            {
                case MapRegion.Africa:
                    return "002";
                case MapRegion.AsiaPacific:
                    return "035";
                case MapRegion.Central_Africa:
                    return "017";
                case MapRegion.Central_America:
                    return "013";
                case MapRegion.Central_Asia:
                    return "143";
                case MapRegion.Eastern_Asia:
                    return "030";
                case MapRegion.Middle_East:
                    return "145";
                case MapRegion.North_America:
                    return "021";
                case MapRegion.Northern_Africa:
                    return "015";
                case MapRegion.Northern_Asia:
                    return "151";
                case MapRegion.Northern_Europe:
                    return "154";
                case MapRegion.South_America:
                    return "005";
                case MapRegion.Southern_Africa:
                    return "018";
                case MapRegion.Southern_Asia:
                    return "034";
                case MapRegion.Southern_Europe:
                    return "039";
                case MapRegion.US_Metro:
                    return "us_metro";
                case MapRegion.Western_Europe:
                    return "155";
                case MapRegion.World:
                    return "world";
                default:
                    return "world";
            }
        }
        public static string Parse(this Enum state)
        {
            return state.ToString().ToLower();
        }
    }


    public class RenderAttributeLiteral : Attribute
    {
    }
}
