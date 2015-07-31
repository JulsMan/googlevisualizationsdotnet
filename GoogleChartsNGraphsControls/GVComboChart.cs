using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVComboChart runat=server></{0}:GVComboChart>")]
    [ToolboxBitmap(typeof(GVComboChart))]
    [DataContract]
    public class GVComboChart : BaseWebControl, IsStackable
    {
       
        #region Math Calcs
        //
        // MAth Calcs from 
        // http://www.codeproject.com/Articles/42492/Using-LINQ-to-Calculate-Basic-Statistics
        //

        private decimal Median(IEnumerable<decimal> source)
        {
            var sortedList = from number in source
                             orderby number
                             select number;

            int count = sortedList.Count();
            int itemIndex = count / 2;
            if (count % 2 == 0) // Even number of items. 
                return (sortedList.ElementAt(itemIndex) +
                        sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items. 
            return sortedList.ElementAt(itemIndex);
        }
        private decimal StandardDeviation(IEnumerable<decimal> source)
        {
            return decimal.Parse( Math.Sqrt( (double) source.Variance()).ToString());
        }
        public decimal Variance(IEnumerable<decimal> source)
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
        #endregion

        public GVComboChart()
            : base()
        {
            this.GviSeriesType = SeriesType.Bars;
            this.GviComboChartLine = new ComboChartLineSeriesList();
            this.LineSeries = new List<ComboChartLineSeries>();
        }
        public void DataBindingEvent(object sender, EventArgs e)
        {
            // depending on the type of WaterMarkLines ... we need to perform some operations...
            

            for (int i = 0; i < this.dt.Columns.Count; i++ )
                this.dt.Columns[i].SetOrdinal(i);
            this.dt.AcceptChanges();

            // keep a list of original columns...
            List<DataColumn> originalColumns = new List<DataColumn>();
            foreach (DataColumn zz in this.dt.Columns)
                originalColumns.Add(zz);


            foreach (ComboChartLineSeries ln in this.LineSeries)
                {

                    if (this.dt.Columns.Contains(ln.LineName))
                        continue;

                    switch (ln.FunctType)
                    {

                        case ComboChartLineSeries.FUNCTION_TYPE.FIXED:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    dt.Rows[i].SetField<decimal>(dc, ln.FixedValue);
                                }
                                this.dt.AcceptChanges();

                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        case ComboChartLineSeries.FUNCTION_TYPE.SUM:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal val = 0;
                                    foreach (DataColumn cc in originalColumns.Where(c => c.DataType.IsNumeric()))
                                    {
                                        val += decimal.Parse(dr[cc].ToString());
                                    }
                                    dt.Rows[i].SetField<decimal>(dc, val);
                                }
                                this.dt.AcceptChanges();

                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        case ComboChartLineSeries.FUNCTION_TYPE.AVG:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal val = 0;
                                    foreach (DataColumn cc in originalColumns.Where(c => c.DataType.IsNumeric()))
                                    {
                                        val += decimal.Parse(dr[cc].ToString());
                                    }
                                    dt.Rows[i].SetField<decimal>(dc, val / originalColumns.Where(c => c.DataType.IsNumeric()).Count());
                                }
                                this.dt.AcceptChanges();

                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        case ComboChartLineSeries.FUNCTION_TYPE.COUNT:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    int val = 0;
                                    foreach (DataColumn cc in originalColumns.Where(c => c.DataType.IsNumeric()))
                                    {
                                        decimal dd = 0;
                                        val += decimal.TryParse(dr[cc].ToString(), out dd) ? 1 : 0;
                                    }
                                    dt.Rows[i].SetField<decimal>(dc, val);
                                }
                                this.dt.AcceptChanges();
                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        case ComboChartLineSeries.FUNCTION_TYPE.STD_DEV:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    List<decimal> median = new List<decimal>();
                                    foreach (DataColumn cc in originalColumns.Where(c => c.DataType.IsNumeric()))
                                    {
                                        median.Add(decimal.Parse(dr[cc].ToString()));
                                    }
                                    dt.Rows[i].SetField<decimal>(dc, StandardDeviation(median));
                                }

                                this.dt.AcceptChanges();

                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        case ComboChartLineSeries.FUNCTION_TYPE.VARIANCE:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    List<decimal> median = new List<decimal>();
                                    foreach (DataColumn cc in originalColumns.Where(c => c.DataType.IsNumeric()))
                                    {
                                        median.Add(decimal.Parse(dr[cc].ToString()));
                                    }
                                    dt.Rows[i].SetField<decimal>(dc, Variance(median));
                                }
                                this.dt.AcceptChanges();

                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        case ComboChartLineSeries.FUNCTION_TYPE.MEDIAN:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();
                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    List<decimal> median = new List<decimal>();
                                    foreach (DataColumn cc in originalColumns.Where(c => c.DataType.IsNumeric()))
                                    {
                                        median.Add( decimal.Parse(dr[cc].ToString()));
                                    }
                                    dt.Rows[i].SetField<decimal>(dc, Median(median));
                                }
                                this.dt.AcceptChanges();

                                ln.Column = this.dt.Columns.Count - 2;
                                this.GviComboChartLine.Add(ln);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                      

                            

                    }
                }


          
        }
        //protected List<WaterMarkLine> WaterMarkLines { get; set; }
        //public void AddWaterMark(WaterMarkLine waterLine)
        //{
        //    this.WaterMarkLines.Add(waterLine);
        //    this.gvi.BindingDataTable += DataBindingEvent;
        //}
        //public void ClearWaterMarks()
        //{
        //    this.WaterMarkLines.Clear();
        //    this.gvi.BindingDataTable -= DataBindingEvent;
        //}
        protected List<ComboChartLineSeries> LineSeries { get; set; }
        public void AddNewSeries(ComboChartLineSeries line)
        {
            this.LineSeries.Add(line);
            this.gvi.BindingDataTable += DataBindingEvent;
        }
        public void ClearSeries()
        {
            this.LineSeries.Clear();
            this.gvi.BindingDataTable -= DataBindingEvent;
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, bar values are stacked (accumulated).")]
        [DefaultValue(false)]
        [DataMember(Name = "isStacked", EmitDefaultValue = true, IsRequired = false)]
        public bool? GviIsStacked
        {
            get
            {
                bool? s = (bool?)ViewState["GviIsStacked"];
                return s;
            }

            set
            {
                ViewState["GviIsStacked"] = value;
            }
        }


       

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"The default line type for any series not specified in the series property. 
            Available values are 'line', 'area', 'bars', 'candlesticks' and 'steppedArea'.")]
        [DataMember(Name = "seriesType", EmitDefaultValue = false, IsRequired = true)]
        public SeriesType GviSeriesType
        {
            get
            {
                SeriesType? s = (SeriesType?) ViewState["GviSeriesType"];
                if (s == null) return SeriesType.Bars;
                return (SeriesType) s;
            }
            set
            {
                ViewState["GviSeriesType"] = value;
            }
        }

        [DataMember(Name="series")]
        public ComboChartLineSeriesList GviComboChartLine
        {
            get
            {
                return (ComboChartLineSeriesList)ViewState["GviComboChartLine"];
            }
            set
            {
                ViewState["GviComboChartLine"] = value;
            }
        }
       



        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;

            // combocharts need to have an Average column or an average column specified to show the average line


            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.COMBO);
            output.Write(Text);
        }
      
        public override string ToString()
        {
            List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
            myconverters.Add(new CustomConvertersColorToRGB());
            myconverters.Add(new CustomConvertersAxis());
            myconverters.Add(new CustomConvertersLegend());
            myconverters.Add(new CustomConverterEnum());
            myconverters.Add(new CustomConverterComboSeries());
            myconverters.Add(new CustomConverterTrendLine());

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
