using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;

namespace GoogleChartsNGraphsControls
{
    [Serializable()]
    public enum TrippleStateBool { Default, True, False, NotSet}
    [Serializable()]
    public enum TitlePosition { Default, In, Out, None }
    [Serializable()]
    public enum LegendPostion { Default, Right, Top, Bottom, In, None }
    [Serializable()]
    public enum HighlightDot { Default, Nearest, Last }
    [Serializable()]
    public enum WindowMode { Default, Window, Opaque, Transparent }
    [Serializable()]
    public enum ScaleType { Default, Fixed, Maximized, AllMaximaized, AllFixed }
    [Serializable()]
    public enum TimelineLegend { Default, SameRow, NewRow }
    [Serializable()]
    public enum PieSliceText { Default, Percentage, Value, Label, None }
    [Serializable()]
    public enum MapRegion 
    {
        Default,
        World, US_Metro, South_America, Central_America, North_America, 
        Africa, Central_Africa, Northern_Africa, Southern_Africa, 
        Eastern_Asia, Southern_Asia, AsiaPacific, Central_Asia,
        Middle_East, Northern_Asia, 
        Northern_Europe, Western_Europe, Southern_Europe
    }
    [Serializable()]
    public enum MapDisplayModes { Default, Auto, Regions, Markers }
    [Serializable()]
    public enum MapResolution { Default, Countries, Provinces, Metros }
    [Serializable()]
    public enum OrgChartSize { Default, Small, Medium, Large }
    [Serializable()]
    public enum CurveType { Default, None, Function }
    [Serializable()]
    public enum ViewWindowsMode { Default, Pretty, Maximized, Explicit }
    [Serializable()]
    public enum AnimationEasing { Default, None, Linear, In, Out, InAndOut }
    [Serializable()]
    public enum Position { Default, In, Out }
    [Serializable()]
    public enum FocusTarget { Default, Datrum, Category }
    [Serializable()]
    public enum CandlestickTheme { Default, Maximized }
    [Serializable()]
    public enum AxisFormat { Default, Percent, Currency, Euro, Number, Date, EuroDate }
    [Serializable()]
    public enum TablePage { Default, Enable, Event, Disable}
    [Serializable()]
    public enum TableFormatters { Default, Arrow, Bar, Color, Date, Number, Pattern}
    [Serializable()]
    public enum SeriesType { Line, Area, Bars, Candlesticks, SteppedArea }

    /// <summary>
    /// TODO: Need to implement this, still need to create valid series JSON and to auto-apply this to the 
    /// best guessed column in the series for the combochart
    /// series: [{color: 'black', visibleInLegend: false},{}, {}, {color: 'red', visibleInLegend: false}]
    ///series: {0:{color: 'black', visibleInLegend: false}, 3:{color: 'red', visibleInLegend: false}}
    ///series:{4:{type:'line'}}
    ///
    /// </summary>
    [DataContract(Name = "series")]
    public class ComboChartColumnFormatClass
    {
        private string[] keycolumnnames = new string[] { "AVERAGE", "AVG" };
        private List<ComboColumnFormat> formattedColumns = new List<ComboColumnFormat>();


        [DataContract()]
        public class ComboColumnFormat
        {
            
            public ComboColumnFormat()
            {
                this.LineSeries = SeriesType.Line;
            }
            public ComboColumnFormat(SeriesType type): this()
            {
               this.LineSeries = type;
            }

            public int? ColumnLineNumber { get; set; }
            public string ColumnLineName { get; set; }


             [DataMember(Name="type")]
            public SeriesType LineSeries { get; set; }
             [DataMember(Name = "color")]
            public Color? color { get; set; }
        }

        public void Add(ComboColumnFormat column)
        {
            this.formattedColumns.Add(column);
        }
        public void Add(ComboColumnFormat column, int iColumnNumberToApply)
        {
            column.ColumnLineNumber = iColumnNumberToApply;
        }
        public void Add(ComboColumnFormat column, string columnNameToApply)
        {
            column.ColumnLineName = columnNameToApply;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    [Serializable()]
    [DataContract(Name = "animation")]
    public class Animation
    {
        public Animation() { }
        public Animation(AnimationEasing Easing, int Duration)
        {
            this.Easing = Easing;
            this.Duration = (int?)Duration;
        }

        [DataMember(Name = "duration")]
        public int? Duration
        {
            get;
            set;
        }

        [DataMember(Name = "easing")]
        public AnimationEasing Easing
        {
            get;
            set;
        }


        public override string ToString()
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            };
            settings.Converters.Add(new CustomConverterEnum());

            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, settings);
        }
    }

    [Serializable()]
    [DataContract(Name = "hAxis")]
    public class hAxis : Axis 
    {
        public hAxis() : base() { }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    [Serializable()]
    [DataContract(Name = "vAxis")]
    public class vAxis : Axis 
    {
        public vAxis() : base() { }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    [Serializable()]
    [DataContract()]
    public abstract class Axis
    {
        public Axis()
        {
            this.Baseline = null;
            this.BaselineColor = null;
            this.Direction = null;
            this.Format = null;
            this.Gridlines = null;
            this.LogScale = null;
            this.MaxAlternation = null;
            this.MaxAlternation = null;
            this.MaxValue = null;
            this.MinValue = null;
            this.ShowTextEvery = null;
            this.SlantedText = null;
            this.SlantedTextAngle = null;
            this.TextPosition = Position.Default;
            this.TextStyle = null;
            this.Title = null;
            this.TitleTextStyle = null;
            this.ViewWindowMode = WindowMode.Default;
        }

        /// <summary>
        /// The baseline for the horizontal axis.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name="baseline", IsRequired=false, EmitDefaultValue=true)]
        public int? Baseline { get; set; }

        /// <summary>
        /// The color of the baseline for the horizontal axis. Can be any HTML color string, for example: 'red' or '#00cc00'.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name = "baselinecolor", IsRequired = false, EmitDefaultValue = true)]
        public System.Drawing.Color? BaselineColor { get; set; }

        /// <summary>
        /// The direction in which the values along the horizontal axis grow. Specify -1 to reverse the order of the values.
        /// </summary>
        [DataMember(Name = "direction", IsRequired = false, EmitDefaultValue = true)]
        public int? Direction { get; set; }

        /// <summary>
        /// An object with members to configure the gridlines on the horizontal axis. To specify properties of this object, you can use object literal notation, as shown here:
        /// {color: '#333', count: 4}
        /// This option is only supported for a continuous axis.
        /// </summary>
        /// 
        [DataMember(Name = "gridlines", IsRequired = false, EmitDefaultValue = true)]
        public Gridlines Gridlines { get; set; }

        /// <summary>
        /// A format string for numeric or date axis labels.
        /// For number axis labels, this is a subset of the decimal formatting ICU pattern set. For instance, {format:'#,###%'} will display values "1,000%", "750%", and "50%" for values 10, 7.5, and 0.5.
        /// For date axis labels, this is a subset of the date formatting ICU pattern set. For instance, {format:'MMM d, y'} will display the value "Jul 1, 2011" for the date of July first in 2011.
        /// The actual formatting applied to the label is derived from the locale the API has been loaded with. For more details, see loading charts with a specific locale.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name = "format", IsRequired = false, EmitDefaultValue = true)]
        public string Format { get; set; }

        /// <summary>
        /// Pre-canned formats for common stuff, or you can roll your own
        /// </summary>
        public AxisFormat Formatted
        {
            private get { return AxisFormat.Default; }
            set
            {
                switch (value)
                {
                    case AxisFormat.Currency:
                        {
                            this.Format = "$ #,###.##";
                            break;
                        }
                    case AxisFormat.Date:
                        {
                            this.Format = "m/dd/yy";
                            break;
                        }
                    case AxisFormat.Euro:
                        {
                            this.Format = "€ ####,##";
                            break;
                        }
                    case AxisFormat.EuroDate:
                        {
                            this.Format = "yy/m/dd";
                            break;
                        }
                    case AxisFormat.Number:
                        {
                            this.Format = "#,###";
                            break;
                        }
                    case AxisFormat.Percent:
                        {
                            this.Format = "#%";
                            break;
                        }
                    default:
                        {
                            this.Format = null;
                            break;
                        }
                    
                }
            }
        }

        /// <summary>
        /// hAxis property that makes the horizontal axis a logarithmic scale (requires all values to be positive). Set to true for yes.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name = "logscale", IsRequired = false, EmitDefaultValue = true)]
        public bool? LogScale { get; set; }

        /// <summary>
        /// Position of the horizontal axis text, relative to the chart area. Supported values: 'out', 'in', 'none'.
        /// </summary>
        [DataMember(Name = "textPosition", IsRequired = false, EmitDefaultValue = true)]
        public Position TextPosition { get; set; }

        /// <summary>
        /// An object that specifies the horizontal axis text style. The object has this format:
        /// {color: <string>, fontName: <string>, fontSize: <number>}
        /// The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.
        /// </summary>
        [DataMember(Name = "textStyle", IsRequired = false, EmitDefaultValue = true)]
        public string TextStyle { get; set; }

        /// <summary>
        /// hAxis property that specifies the title of the horizontal axis.
        /// </summary>
        [DataMember(Name = "title", IsRequired = false, EmitDefaultValue = true)]
        public string Title { get; set; }

        /// <summary>
        /// An object that specifies the horizontal axis title text style. The object has this format:
        /// {color: <string>, fontName: <string>, fontSize: <number>}
        /// The color can be any HTML color string, for example: 'red' or '#00cc00'. Also see fontName and fontSize.
        /// </summary>
        [DataMember(Name = "titleTextStyle", IsRequired = false, EmitDefaultValue = true)]
        public string TitleTextStyle { get; set; }

        /// <summary>
        /// If true, draw the horizontal axis text at an angle, to help fit more text along the axis; if false, draw horizontal axis text upright. Default behavior is to slant text if it cannot all fit when drawn upright. Notice that this option is available only when the hAxis.textPosition is set to 'out' (which is the default).
        /// This option is only supported for a discrete axis.
        /// </summary>
        [DataMember(Name = "slantedText", IsRequired = false, EmitDefaultValue = true)]
        public bool? SlantedText { get; set; }

        /// <summary>
        /// The angle of the horizontal axis text, if it's drawn slanted. Ignored if hAxis.slantedText is false, or is in auto mode, and the chart decided to draw the text horizontally.
        /// This option is only supported for a discrete axis.
        /// </summary>
        [DataMember(Name = "slantedTextAngle", IsRequired = false, EmitDefaultValue = true)]
        public int? SlantedTextAngle { get; set; }

        /// <summary>
        /// Maximum number of levels of horizontal axis text. If axis text labels become too crowded, the server might shift neighboring labels up or down in order to fit labels closer together. This value specifies the most number of levels to use; the server can use fewer levels, if labels can fit without overlapping.
        /// This option is only supported for a discrete axis.
        /// </summary>
        [DataMember(Name = "maxAlternation", IsRequired = false, EmitDefaultValue = true)]
        public int? MaxAlternation { get; set; }

        /// <summary>
        /// How many horizontal axis labels to show, where 1 means show every label, 2 means show every other label, and so on. Default is to try to show as many labels as possible without overlapping.
        /// This option is only supported for a discrete axis.
        /// </summary>
        [DataMember(Name = "showTextEvery", IsRequired = false, EmitDefaultValue = true)]
        public int? ShowTextEvery { get; set; }

        /// <summary>
        /// hAxis property that specifies the highest horizontal axis grid line. The actual grid line will be the greater of two values: the maxValue option value, or the highest data value, rounded up to the next higher grid mark.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name = "maxValue", IsRequired = false, EmitDefaultValue = true)]
        public int? MaxValue { get; set; }

        /// <summary>
        /// hAxis property that specifies the lowest horizontal axis grid line. The actual grid line will be the lower of two values: the minValue option value, or the lowest data value, rounded down to the next lower grid mark.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name = "minValue", IsRequired = false, EmitDefaultValue = true)]
        public int? MinValue { get; set; }

        /// <summary>
        /// Specifies how to scale the horizontal axis to render the values within the chart area. The following string values are supported:
        /// 'pretty' - Scale the horizontal values so that the maximum and minimum data values are rendered a bit inside the left and right of the chart area.
        /// 'maximized' - Scale the horizontal values so that the maximum and minimum data values touch the left and right of the chart area.
        /// 'explicit' - Specify the left and right scale values of the chart area. Data values outside these values will be cropped. You must specify an hAxis.viewWindow object describing the maximum and minimum values to show.
        /// This option is only supported for a continuous axis.
        /// </summary>
        [DataMember(Name = "viewWindowMode",IsRequired=false, EmitDefaultValue=true)]
        public WindowMode ViewWindowMode { get; set; }


        public override string ToString()
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            };
            settings.Converters.Add(new CustomConverterEnum());

            string s =  Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, settings);
            return s;
        }

       

    }

    [Serializable()]
    [DataContract(Name = "gridlines")]
    public class Gridlines
    {
        public Gridlines() { }
        [DataMember(Name = "color")]
        public System.Drawing.Color? Color { get; set; }

        [DataMember(Name = "count")]
        public int? Count { get; set; }
    }

    [Serializable()]
    [DataContract(Name="legend")]
    public class Legend
    {
        public Legend() 
        {
            this.LegendPosition = LegendPostion.Default;
            this.TextStyle = new TextStyle();
        }

        public Legend(LegendPostion Position): this()
        {
            this.LegendPosition = Position;
        }

        public Legend(LegendPostion Position, TextStyle TextStyle)
            : this(Position)
        {
            this.TextStyle = TextStyle;
        }

        [DataMember(Name = "postition", IsRequired = false, EmitDefaultValue = true)]
        public LegendPostion LegendPosition
        {
            get;
            set;
        }

        [DataMember(Name = "textStyle", IsRequired = false, EmitDefaultValue = true)]
        public TextStyle TextStyle
        {
            get;
            set;
        }

        public override string ToString()
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            };
            settings.Converters.Add(new CustomConverterEnum());

            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, settings);
        }
    }

    /// <summary>
    /// {color: <string>, fontName: <string>, fontSize: <number>}
    /// </summary>
    [Serializable()]
    [DataContract(Name = "textStyle")]
    public class TextStyle
    {
        public TextStyle()
        {
            this.Color = Color.Black;
        }

        [DataMember(Name="color")]
        public Color Color { get; set; }

        [DataMember(Name = "fontName")]
        public string FontName { get; set; }

        [DataMember(Name = "fontSize")]
        public int? FontSize { get; set; }

        public override string ToString()
        {
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None);
            return s;
        }
    }


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
