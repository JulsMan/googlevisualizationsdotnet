using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartsNGraphsControls
{
    public interface IGoogleTableFormatterControl
    {
        /*
         * var formatter = new google.visualization.BarFormat({width: 120});
         * formatter.format(data, 1); // Apply formatter to second column
         * 
         */
        List<TableFormatter> GviFormatter { get; set; }

    }


    public class TableFormatter
    {
        public TableFormatter()
        {
            this.Formatter = FormatType.ArrowFormat;
        }
        public enum FormatType { ArrowFormat, BarFormat, ColorFormat, DateFormat, NumberFormat, PatternFormat }

        public FormatType Formatter { get; set; }        // BarFormat
        public int? GviFormatColumn { get; set; }

        public override string ToString()
        {
            return this.Formatter.ToString();
        }
    }



    
}
