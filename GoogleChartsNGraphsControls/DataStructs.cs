using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GoogleChartsNGraphsControls
{
    public struct MapCoordinate
    {
        public decimal Lon;
        public decimal Lat;
        public MapCoordinate(decimal Lon, decimal Lat)
        {
            this.Lon = Lon;
            this.Lat = Lat;
        }
    }
    public class TimelineEvent
    {
        public TimelineEvent() { }
        public TimelineEvent(string EventCategory, DateTime EventDate, decimal ChartValue) 
        {
            this.EventCategory = EventCategory;
            this.EventDate = EventDate;
            this.YValue = ChartValue;
        }
        public TimelineEvent(string EventCategory, DateTime EventDate, int ChartValue)
        {
            this.EventCategory = EventCategory;
            this.EventDate = EventDate;
            this.YValue = ChartValue;
        }
        
        public TimelineEvent(string EventCategory, DateTime EventDate, Decimal value, string AnnotationTitle, string AnnotationText)
            : this(EventCategory, EventDate, value)
        {
            this.OptionalAnnotationTitle = AnnotationTitle;
            this.OptionalAnnotationText = AnnotationText;
        }
        public TimelineEvent(string EventCategory, DateTime EventDate, int value, string AnnotationTitle, string AnnotationText)
            : this(EventCategory, EventDate, value)
        {
            this.OptionalAnnotationTitle = AnnotationTitle;
            this.OptionalAnnotationText = AnnotationText;
        }

        public string EventCategory { get; set; }       // required
        public DateTime EventDate { get; set; }         // required
        public decimal YValue { get; set; }             // required
        public string OptionalAnnotationTitle { get; set; }
        public string OptionalAnnotationText { get; set; }
    }
    public class CHAPTimelineEvent
    {
        public class ImgFormatContent
        {
            public ImgFormatContent() { }
            public ImgFormatContent(string img, string title)
            {
                this.IconUrl = img;
                this.Title = title;
            }
            public string IconUrl { get; set; }
            public string Title { get; set; }
            public override string ToString()
            {
                return string.Format("<label class='chap-timeln-node' />{1}</lable><br/><img src='{0}' class='chap-timeln-node' />",this.IconUrl, this.Title);
            }
        }
        public CHAPTimelineEvent()
        {
            this.start = DateTime.MinValue;
            this.end = DateTime.MinValue;
            this.content = string.Empty;
            this.editable = true;
            this.group = string.Empty;
        }
        public CHAPTimelineEvent(DateTime start, string content): this()
        {
            this.start = start;
            this.content = content;
        }
        public CHAPTimelineEvent(DateTime start, DateTime end, string content) : this()
        {
            this.start = start;
            this.end = end;
            this.content = content;
        }
        public CHAPTimelineEvent(DateTime start, ImgFormatContent content) : this()
        {
            this.start = start;
            this.content = content.ToString();
        }
        public CHAPTimelineEvent(DateTime start, DateTime end, ImgFormatContent content) : this()
        {
            this.start = start;
            this.end = end;
            this.content = content.ToString();
        }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string content { get; set; }
        public bool editable { get; set; }
        public string group { get; set; }
        public object[] ToRow()
        {
            if (start == DateTime.MinValue || string.IsNullOrEmpty(content))
                throw new Exception("Maleformed CHAP Timeline event - missing start date or content");

            return new object[] 
            {
                start,
                end,
                content,
                editable,
                group
            };
        }
    }

    public class WaterMarkLine : ComboChartLineSeries
    {
        public WaterMarkLine(System.Drawing.Color color, decimal FixedValueAt, string Title)
        {
            this.FunctType = FUNCTION_TYPE.FIXED;
            this.LineType = GoogleChartsNGraphsControls.SeriesType.Area;
            this.LineName = Title;
            this.FixedValue = FixedValueAt;
            this.LineColor = color;
            this.AddOption("opacity", 1.0);
        }
    }

    public class GviConfigOption : Attribute
    {
        public GviConfigOption() { }
    }
   
    public class GviAnimationOption : Attribute
    {
        public GviAnimationOption() { }
    }
    public class GviLegendOption : Attribute
    {
        public GviLegendOption() { }
    }
    public class GviEventOption : Attribute
    {
        public string EventName;
        public GviEventOption() { }
        public GviEventOption(string EventName) 
        {
            this.EventName = EventName;
        }
        public override string ToString()
        {
            return EventName;
        }
    }
    
    
    /// <summary>
    ///  Signifies that this class will be run and will fill in another, usually string, value with JSON
    /// </summary>
    //public class GviClass : Attribute
    //{
    //    private string JSONClassName;
    //    public GviClass(string JSONClassName)
    //    {
    //        this.JSONClassName = JSONClassName;
    //    }
    //    public override string ToString()
    //    {
    //        return this.JSONClassName;
    //    }
    //}
    
    public static class GviExtensions
    {
        public static string HexConverter(this System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        public static string HexConverter(this System.Drawing.Color? c)
        {
            if (c == null) return string.Empty;
            return HexConverter((System.Drawing.Color)c);
        }
        public static decimal Variance(this IEnumerable<decimal> source)
        {
            int n = 0;
            decimal mean = 0;
            decimal M2 = 0;

            foreach (decimal x in source)
            {
                n = n + 1;
                decimal delta = x - mean;
                mean = mean + delta / n;
                M2 += delta * (x - mean);
            }
            return M2 / (n - 1);
        }
        public static bool IsNumeric(this Type t)
        {
            if (t == typeof(int))
                return true;
            if (t == typeof(Int16))
                return true;
            if (t == typeof(Int32))
                return true;
            if (t == typeof(Int64))
                return true;
            if (t == typeof(decimal))
                return true;
            if (t == typeof(Decimal))
                return true;
            if (t == typeof(long))
                return true;
            if (t == typeof(float))
                return true;
            if (t == typeof(double))
                return true;
            if (t == typeof(Double))
                return true;
            if (t == typeof(short))
                return true;
            if (t == typeof(Single))
                return true;
            if (t == typeof(uint))
                return true;
            if (t == typeof(UInt16))
                return true;
            if (t == typeof(UInt32))
                return true;
            if (t == typeof(UInt64))
                return true;
            if (t == typeof(UIntPtr))
                return true;
            if (t == typeof(ulong))
                return true;

            return false;
        }
        public static string LowerCaseFirst(this string str)
        {
            return char.ToLower(str[0]) + str.Substring(1);
        }
        public static string UpperCaseFirst(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
        public static string GVINameParse(this string str)
        {
            if (str.StartsWith("Gvi", true, System.Globalization.CultureInfo.CurrentCulture))
                str =  str.Substring(3).LowerCaseFirst();
            if (str.StartsWith("GV", true, System.Globalization.CultureInfo.CurrentCulture))
                str =  str.Substring(2).LowerCaseFirst();
            else
                str =  str.LowerCaseFirst();

            return str.Replace("_", ".");   // replace the '_' with '.' for subclassing
        }

    }
}
