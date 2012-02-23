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

}
