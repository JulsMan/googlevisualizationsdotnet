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


        string GviFormatterParams { get; set; }
        string Formatter { get; }        // BarFormat
        int? GviFormatColumn { get; set;  }
    }
}
