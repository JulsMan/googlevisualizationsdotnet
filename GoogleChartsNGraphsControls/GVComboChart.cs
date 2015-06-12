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
       
        
        public GVComboChart()
            : base()
        {
            this.GviSeriesType = SeriesType.Bars;
            this.GviComboChartLine = new ComboChartLineSeriesList();
            this.WaterMarkLines = new List<WaterMarkLine>();
        }
        public void DataBindingEvent(object sender, EventArgs e)
        {
            // depending on the type of WaterMarkLines ... we need to perform some operations...
            

            for (int i = 0; i < this.dt.Columns.Count; i++ )
                this.dt.Columns[i].SetOrdinal(i);
            this.dt.AcceptChanges();

                foreach (WaterMarkLine ln in this.WaterMarkLines)
                {
                    if (this.dt.Columns.Contains(ln.LineName))
                        continue;

                    switch (ln.LINETYPE)
                    {

                        case WaterMarkLine.LineType.FIXED:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    dt.Rows[i].SetField<decimal>(dc, ln.LineValue);
                                }
                                this.dt.AcceptChanges();

                                this.GviComboChartLine.Add(new ComboChartLineSeries()
                                {
                                    Column = this.dt.Columns.Count - 2,
                                    LineType = SeriesType.Line
                                });
                                break;
                            }
                        case WaterMarkLine.LineType.SUM:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal val = dt.Columns.Cast<DataColumn>().Sum(oo => (decimal) dr[dc]);
                                    dt.Rows[i].SetField<decimal>(dc, val);
                                }
                                this.dt.AcceptChanges();

                                this.GviComboChartLine.Add( new ComboChartLineSeries()
                                {
                                    Column = this.dt.Columns.Count - 2,
                                    LineType = SeriesType.Line
                                });
                                break;
                            }
                        case WaterMarkLine.LineType.AVG:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal val = dt.Columns.Cast<DataColumn>().Average(oo => (decimal)dr[dc]) ;
                                    dt.Rows[i].SetField<decimal>(dc, val);
                                }
                                this.dt.AcceptChanges();

                                this.GviComboChartLine.Add(new ComboChartLineSeries()
                                {
                                    Column = this.dt.Columns.Count - 2,
                                    LineType = SeriesType.Line
                                });
                                break;
                            }
                        case WaterMarkLine.LineType.COUNT:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal val = dt.Columns.Cast<DataColumn>().Count(oo => oo.DataType.IsNumeric());
                                    dt.Rows[i].SetField<decimal>(dc, val);
                                }
                                this.dt.AcceptChanges();

                                this.GviComboChartLine.Add(new ComboChartLineSeries()
                                {
                                    Column = this.dt.Columns.Count - 2,
                                    LineType = SeriesType.Line
                                });
                                break;
                            }
                        case WaterMarkLine.LineType.STD_DEV:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal count = dt.Columns.Cast<DataColumn>().Count(oo => oo.DataType.IsNumeric());
                                    decimal val = dt.Columns.Cast<DataColumn>().Average(oo => (decimal)dr[dc]);
                                    decimal std_dev = dt.Columns.Cast<DataColumn>().Sum(oo => ((decimal)dr[dc] - val) * ((decimal)dr[dc] - val));

                                    dt.Rows[i].SetField<decimal>(dc, decimal.Parse( Math.Sqrt( (double)std_dev / (double)count).ToString()));
                                }
                                this.dt.AcceptChanges();

                                this.GviComboChartLine.Add( new ComboChartLineSeries()
                                {
                                    Column = this.dt.Columns.Count - 2,
                                    LineType = SeriesType.Line
                                });
                                break;
                            }
                        case WaterMarkLine.LineType.VARIANCE:
                            {
                                DataColumn dc = new DataColumn(ln.LineName, typeof(decimal));
                                dc.Caption = ln.LineName;
                                this.dt.Columns.Add(dc);
                                dc.SetOrdinal(this.dt.Columns.Count - 1);

                                this.dt.AcceptChanges();

                                for (int i = 0; i < this.dt.Rows.Count; i++)
                                {
                                    DataRow dr = dt.Rows[i];
                                    decimal dd = dt.Columns.Cast<DataColumn>().Where(o => o.DataType.IsNumeric()).Select(o => (decimal)dr[dc]).Variance();
                                    dt.Rows[i].SetField<decimal>(dc, dd);
                                }
                                this.dt.AcceptChanges();

                                this.GviComboChartLine.Add( new ComboChartLineSeries()
                                {
                                    Column = this.dt.Columns.Count - 2,
                                    LineType = SeriesType.Line
                                });
                                break;
                            }
                        default:
                            {
                                break;
                            }
                      

                            

                    }
                }


          
        }
        protected List<WaterMarkLine> WaterMarkLines { get; set; }
        public void AddWaterMark(WaterMarkLine waterLine)
        {
            this.WaterMarkLines.Add(waterLine);
            this.gvi.BindingDataTable += DataBindingEvent;
        }
        public void ClearWaterMarks()
        {
            this.WaterMarkLines.Clear();
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
