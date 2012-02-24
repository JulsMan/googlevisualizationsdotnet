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


        TableFormatter GviFormatter { get; set; }

        TableFormatter.FormatType GviFormatType { get; set; }
        int? GviFormatColumn { get; set; }
    }



    
}
