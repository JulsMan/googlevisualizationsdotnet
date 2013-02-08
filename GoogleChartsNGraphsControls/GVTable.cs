using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVTable runat=server></{0}:GVTable>")]
    [ToolboxBitmap(typeof(GVTable))]
    [DataContract]
    public class GVTable : BaseWebControl, IGoogleTableFormatterControl
    {

        public GVTable()
        {
            this.GviPage = TablePage.Default;
            this.GviSort = TablePage.Default;
            this.GviFormatter = new List<TableFormatter>();
            if (this.GviFormatter.Count == 0)
            {
                this.GviFormatter.Add(new TableFormatter()
                {
                    Formatter = TableFormatter.FormatType.ArrowFormat,
                    GviFormatColumn = 1
                });
            }
            

        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, formatted values of cells that include HTML tags will be rendered as HTML. If set to false, most custom formatters will not work properly.")]
        [DefaultValue(false)]
        [DataMember(Name = "allowHtml")]
        public bool? GviAllowHtml
        {
            get
            {
                bool? s = (bool?)ViewState["GviAllowHtml"];
                return s;
            }

            set
            {
                ViewState["GviAllowHtml"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("Determines if alternating color style will be assigned to odd and even rows.")]
        [DefaultValue(true)]
        [DataMember(Name = "alternatingRowStyle")]
        public bool? GVIAlternatingRowStyle
        {
            get
            {
                bool? s = (bool?)ViewState["GVIAlternatingRowStyle"];
                return s;
            }

            set
            {
                ViewState["GVIAlternatingRowStyle"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"headerRow - Assigns a class name to the table header row (<tr> element).
            tableRow - Assigns a class name to the non-header rows (<tr> elements).
            oddTableRow - Assigns a class name to odd table rows (<tr> elements). Note: the alternatingRowStyle option must be set to true.
            selectedTableRow - Assigns a class name to the selected table row (<tr> element).
            hoverTableRow - Assigns a class name to the hovered table row (<tr> element).
            headerCell - Assigns a class name to all cells in the header row (<td> element).
            tableCell - Assigns a class name to all non-header table cells (<td> element).
            rowNumberCell - Assigns a class name to the cells in the row number column (<td> element). Note: the showRowNumber option must be set to true.
            Example: var cssClassNames = {headerRow: 'bigAndBoldClass', hoverTableRow: 'highlightClass'};")]
        [DefaultValue(null)]
        [DataMember(Name = "cssClassNames")]
        public object GVICssClassNames
        {
            get
            {
                object s = (object)ViewState["GVICssClassNames"];
                return s;
            }

            set
            {
                ViewState["GVICssClassNames"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The row number for the first row in the dataTable. Used only if showRowNumber is true.")]
        [DefaultValue(1)]
        [DataMember(Name = "firstRowNumber")]
        public int? GVIFirstRowNumber
        {
            get
            {
                int? s = (int?)ViewState["GVIFirstRowNumber"];
                return s;
            }

            set
            {
                ViewState["GVIFirstRowNumber"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If and how to enable paging through the data. Choose one of the following string values:
            'enable' - The table will include page-forward and page-back buttons. Clicking on these buttons will perform the paging operation and change the displayed page. You might want to also set the pageSize option.
            'event' - The table will include page-forward and page-back buttons, but clicking them will trigger a 'page' event and will not change the displayed page. This option should be used when the code implements its own page turning logic. See the TableQueryWrapper example for an example of how to handle paging events manually.
            'disable' - [Default] Paging is not supported.")]
        [DefaultValue("disable")]
        [DataMember(Name = "page")]
        public TablePage GviPage
        {
            get
            {
                TablePage s = (TablePage)ViewState["GviPage"];
                return s;
            }

            set
            {
                ViewState["GviPage"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The number of rows in each page, when paging is enabled with the page option.")]
        [DefaultValue(10)]
        [DataMember(Name = "pageSize")]
        public int? GviPageSize
        {
            get
            {
                int? s = (int?)ViewState["GviPageSize"];
                return s;
            }

            set
            {
                ViewState["GviPageSize"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Adds basic support for right-to-left languages (such as Arabic or Hebrew) by reversing the column order of the table, so that column zero is the rightmost column, and the last column is the leftmost column. This does not affect the column index in the underlying data, only the order of display. Full bi-directional (BiDi) language display is not supported by the table visualization even with this option. This option will be ignored if you enable paging (using the page option), or if the table has scroll bars because you have specified height and width options smaller than the required table size.")]
        [DefaultValue(false)]
        [DataMember(Name = "rtlTable")]
        public bool? GviRtlTable
        {
            get
            {
                bool? s = (bool?)ViewState["GviRtlTable"];
                return s;
            }

            set
            {
                ViewState["GviRtlTable"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Sets the horizontal scrolling position, in pixels, if the table has horizontal scroll bars because you have set the width property. The table will open scrolled that many pixels past the leftmost column.")]
        [DefaultValue(0)]
        [DataMember(Name = "scrollLeftStartPosition")]
        public int? GviScrollLeftStartPosition
        {
            get
            {
                int? s = (int?)ViewState["GviScrollLeftStartPosition"];
                return s;
            }

            set
            {
                ViewState["GviScrollLeftStartPosition"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If set to true, shows the row number as the first column of the table.")]
        [DefaultValue(false)]
        [DataMember(Name = "showRowNumber")]
        public bool? GviShowRowNumber
        {
            get
            {
                bool? s = (bool?)ViewState["GviShowRowNumber"];
                return s;
            }

            set
            {
                ViewState["GviShowRowNumber"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If and how to sort columns when the user clicks a column heading. If sorting is enabled, consider setting the sortAscending and sortColumn properties as well. Choose one of the following string values:
            'enable' - [Default] Users can click on column headers to sort by the clicked column. When users click on the column header, the rows will be automatically sorted, and a 'sort' event will be triggered.
            'event' - When users click on the column header, a 'sort' event will be triggered, but the rows will not be automatically sorted. This option should be used when the page implements its own sort. See the TableQueryWrapper example for an example of how to handle sorting events manually.
            'disable' - Clicking a column header has no effect.")]
        [DefaultValue("enable")]
        [DataMember(Name = "sort")]
        public TablePage GviSort
        {
            get
            {
                TablePage s = (TablePage)ViewState["GviSort"];
                return s;
            }

            set
            {
                ViewState["GviSort"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The order in which the initial sort column is sorted. True for ascending, false for descending. Ignored if sortColumn is not specified.")]
        [DefaultValue(false)]
        [DataMember(Name = "sortAscending")]
        public bool? GviSortAscending
        {
            get
            {
                bool? s = (bool?)ViewState["GviSortAscending"];
                return s;
            }

            set
            {
                ViewState["GviSortAscending"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("The default font face for all text in the chart. You can override this using properties for specific chart elements.")]
        [DefaultValue(-1)]
        [DataMember(Name = "sortColumn")]
        public int? GviSortColumn
        {
            get
            {
                int? s = (int?)ViewState["GviSortColumn"];
                return s;
            }

            set
            {
                ViewState["GviSortColumn"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The first table page to display. Used only if page is in mode enable/event.")]
        [DefaultValue(0)]
        [DataMember(Name = "startPage")]
        public int? GviStartPage
        {
            get
            {
                int? s = (int?)ViewState["GviStartPage"];
                return s;
            }

            set
            {
                ViewState["GviStartPage"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleFormatOptions")]
        [Description(@"Sets the width of the visualization's container element. You can use standard HTML units (for example, '100px', '80em', '60'). If no units are specified the number is assumed to be pixels. If not specified, the browser will set the width automatically to fit the table; if set smaller than the size required by the table, will add a horizontal scroll bar.")]
        [DefaultValue("")]
        public int? GviFormatColumn
        {
            get
            {
                if (this.GviFormatter.Count == 0)
                    this.GviFormatter.Add(new TableFormatter());

                return this.GviFormatter.First().GviFormatColumn;
            }

            set
            {
                if (this.GviFormatter.Count == 0)
                    this.GviFormatter.Add(new TableFormatter());

                this.GviFormatter.First().GviFormatColumn = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleFormatOptions")]
        [Description(@"Sets the width of the visualization's container element. You can use standard HTML units (for example, '100px', '80em', '60'). If no units are specified the number is assumed to be pixels. If not specified, the browser will set the width automatically to fit the table; if set smaller than the size required by the table, will add a horizontal scroll bar.")]
        [DefaultValue("")]
        public TableFormatter.FormatType GviFormatType
        {
            get
            {
                if (this.GviFormatter.Count == 0)
                    this.GviFormatter.Add(new TableFormatter());

                return this.GviFormatter.First().Formatter;
            }
            set
            {
                if (this.GviFormatter.Count == 0)
                    this.GviFormatter.Add(new TableFormatter());

                this.GviFormatter.First().Formatter = value;
            }
        }

        [Bindable(false)]
        public List<TableFormatter> GviFormatter
        {
            get
            {
                List<TableFormatter> s = (List<TableFormatter>)ViewState["GviTableFormatter"];
                return s;
            }

            set
            {
                ViewState["GviTableFormatter"] = value;
            }
        }


        public void ChartData(string Name, int Value)
        {

            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(String));
                this.dt.Columns.Add("Value", typeof(decimal));
            }

            this.dt.Rows.Add(new object[] { Name, (decimal)Value });
        }
        public void ChartData(string Name, decimal Value)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(String));
                this.dt.Columns.Add("Value", typeof(decimal));
            }

            this.dt.Rows.Add(new object[] { Name, Value });
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.TABLEARROW);
            output.Write(Text);
        }



        public override string ToString()
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

            string s = string.Empty;
            s = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None, settings);
            return s;
        }


    }
}
