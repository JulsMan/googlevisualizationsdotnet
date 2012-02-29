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
        public TableFormatter(FormatType Formatter, int FormatColumn)
        {
            this.Formatter = Formatter;
            this.GviFormatColumn = (int?) FormatColumn;
        }
        public TableFormatter(FormatType Formatter, int FormatColumn, string FormatParamsJson)
            : this(Formatter, FormatColumn)
        {
            this.FormatterParams = FormatParamsJson;
        }


        public enum FormatType { ArrowFormat, BarFormat, ColorFormat, DateFormat, NumberFormat, PatternFormat }
        public string FormatterParams { get; set; }     // Json params
        public FormatType Formatter { get; set; }        // BarFormat
        public int? GviFormatColumn { get; set; }

        public override string ToString()
        {
            return this.Formatter.ToString();
        }
    }
}
