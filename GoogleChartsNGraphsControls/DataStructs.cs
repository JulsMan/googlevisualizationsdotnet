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


    public class WaterMarkLine
    {
        public WaterMarkLine()
        {
            this.LINETYPE = LineType.AVG;
            this.LineColor = System.Drawing.Color.AliceBlue;
            this.LineName = "Watermark";
        }
        public enum LineType { FIXED, AVG, COUNT, SUM, MAX, MIN, STD_DEV, VARIANCE };

        public LineType LINETYPE { get; set; }
        public System.Drawing.Color LineColor { get; set; }
        public string LineName { get; set; }
        public decimal LineValue { get; set; }
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
