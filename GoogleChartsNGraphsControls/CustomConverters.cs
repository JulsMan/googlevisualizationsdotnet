using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;

namespace GoogleChartsNGraphsControls
{
    internal static class ConverterTools
    {
        internal static string RGBtoHex(System.Drawing.Color?[] c)
        {
            List<string> foo = new List<string>();
            foreach (Color? cc in c)
                if (cc != null)
                    foo.Add(RGBtoHex((Color)cc));
            return string.Format("[ {0} ]", string.Join(",", foo.ToArray()));
        }
        internal static string RGBtoHex(System.Drawing.Color[] c)
        {
            List<string> foo = new List<string>();
            foreach (Color cc in c)
                    foo.Add(RGBtoHex((Color)cc));
            return string.Format("[ {0} ]", string.Join(",", foo.ToArray()));
        }
        internal static string RGBtoHex(System.Drawing.Color c)
        {
            return string.Format("'{0}'", RGBtoHex(c.R, c.G, c.B));
        }
        internal static string RGBtoHex(System.Drawing.Color? c)
        {
            if (c == null) return string.Empty;
            return RGBtoHex((Color)c);
        }
        internal static string RGBtoHex(byte R, byte G, byte B)
        {
            return String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);
        }
    }

    internal class CustomConvertersColorToRGB: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(System.Drawing.Color) || objectType == typeof(System.Drawing.Color[]))
                return true;
            if (objectType == typeof(System.Drawing.Color?) || objectType == typeof(System.Drawing.Color?[]))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<Color> clr = new List<Color>();

            if (value is Color[])
            {
                foreach (Color c in ((Color[])value))
                    clr.Add(c);
            }
            else if (value is Color?[])
            {
                foreach (Color? c in ((Color?[])value))
                    if (c != null)
                        clr.Add((Color)c);
            }
            else if (value is Color?)
            {
                if (value != null)
                    clr.Add((Color)value);
            }
            else if (value is Color)
                clr.Add((Color)value);

            
            writer.WriteStartArray();
            foreach (Color c in clr)
               writer.WriteRawValue(ConverterTools.RGBtoHex(c));
            writer.WriteEndArray();
        }
    }

    internal class CustomConvertersAxis : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(hAxis) || objectType == typeof(vAxis))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //if (value is hAxis)
            //{
            //    writer.WritePropertyName("hAxis");
            //}
            //else if (value is vAxis)
            //{
            //     writer.WritePropertyName("hAxis");
            //}
            writer.WriteWhitespace(" ");
            string json = ((Axis)value).ToString();
            writer.WriteRawValue(json);

        }
    }

    internal class CustomConvertersLegend : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            
            if (objectType == typeof(Legend))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {


            if ((value != null) && ((Legend)value).LegendPosition != LegendPostion.Default)
            {
                string s = value.ToString();
                writer.WriteRaw(s);
            }
            else
            {
                writer.WriteRaw("{}");
            }
        }
    }

    internal class CustomConverterEnum : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.BaseType == typeof(Enum))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
            if (value == null)
                writer.WriteValue("");

            if (value.GetType() == typeof(TrippleStateBool))
            {
                string s = Enum.GetName(value.GetType(), value);
                if (string.Compare(s, "default", true) == 0)
                {
                    writer.WriteValue("Default");
                    return;
                }
                writer.WriteValue(s.LowerCaseFirst());
            }
            else
            {
                string s = Enum.GetName(value.GetType(), value);
                writer.WriteValue(s.LowerCaseFirst());
            }
        }
    }

    internal class CustomConverterComboSeries : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(ComboChartLineSeries))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            if (value == null)
                writer.WriteValue("");

            if (value.GetType() == typeof(ComboChartLineSeries))
            {
                ComboChartLineSeries v = (ComboChartLineSeries)value;
                writer.WriteRawValue(v.ToString());
            }
           
        }
    }

    internal class CustomConverterTrippleStateBool : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.BaseType == typeof(TrippleStateBool))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string s = Enum.GetName(value.GetType(), value);
            //writer.WriteValue(s.LowerCaseFirst());
            writer.WriteRawValue(s.LowerCaseFirst());
        }
    }

    internal class CustomConverterTrendLine : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(TrendLine[]) )
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
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

          
       
            TrendLine[] lines = value as TrendLine[];

            if (lines.Count() == 0) return;

            writer.WriteStartObject();

            for (int i = 0; i < lines.Count(); i++ )
            {
                writer.WritePropertyName(i.ToString());
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(lines[i], Formatting.None, settings);
                json = BaseGVI.FixJSON(json);
                json = json.Trim('"');
                writer.WriteRawValue( json );
            }


            writer.WriteEndObject();
        }
    }



    internal class CustomConverterInterval : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(Interval[]))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
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



            Interval[] lines = value as Interval[];

          

            //writer.WritePropertyName("intervals");
            writer.WriteRawValue("{style:'bars', color:'series-color'}");


            if (lines.Count() == 0) return;

            //writer.WriteStartObject();

            //for (int i = 0; i < lines.Count(); i++)
            //{
            //    writer.WritePropertyName(i.ToString());
            //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(lines[i], Formatting.None, settings);
            //    json = BaseGVI.FixJSON(json);
            //    json = json.Trim('"');
            //    writer.WriteRawValue(json);
            //}


            //writer.WriteEndObject();
        }
    }
  

}
