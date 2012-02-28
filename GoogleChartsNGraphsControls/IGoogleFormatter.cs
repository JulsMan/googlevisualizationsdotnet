using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartsNGraphsControls
{
    public interface IGoogleFormatter
    {
        /*
         * var formatter = new google.visualization.BarFormat({width: 120});
         * formatter.format(data, 1); // Apply formatter to second column
         * 
         */
        int? GviFormatColumn { get; set; }

    }


    public class TableFormatter : IGoogleFormatter
    {
        public TableFormatter()
        {
            this.Formatter = FormatType.Arrow;
        }
        public enum FormatType { Arrow, Bar, Color, Date, Number, Pattern }

        public FormatType Formatter { get; set; }        // BarFormat
        public int? GviFormatColumn { get; set; }

        public override string ToString()
        {
            return this.Formatter.ToString();
        }
    }



    
}
