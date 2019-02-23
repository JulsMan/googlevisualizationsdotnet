using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVAreaChart runat=server></{0}:GVAreaChart>")]
    [ToolboxBitmap(typeof(GVAreaChart))]
    [DataContract]
    public class GVAreaChart : BaseWebControl, IsStackable
    {
        public GVAreaChart()
        {
            this.GviLineSeriesList = new ComboChartLineSeriesList();
            this.LineSeries = new List<ComboChartLineSeries>();

        }


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
        public void DataBindingEvent(object sender, EventArgs e)
        {
            // depending on the type of WaterMarkLines ... we need to perform some operations...


            for (int i = 0; i < this.dt.Columns.Count; i++)
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
                            this.GviLineSeriesList.Add(ln);
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
                            this.GviLineSeriesList.Add(ln);
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
                            this.GviLineSeriesList.Add(ln);
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
                            this.GviLineSeriesList.Add(ln);
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
                                dt.Rows[i].SetField<decimal>(dc, MathUtils.StandardDeviation(median));
                            }

                            this.dt.AcceptChanges();

                            ln.Column = this.dt.Columns.Count - 2;
                            this.GviLineSeriesList.Add(ln);
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
                                dt.Rows[i].SetField<decimal>(dc, MathUtils.Variance(median));
                            }
                            this.dt.AcceptChanges();

                            ln.Column = this.dt.Columns.Count - 2;
                            this.GviLineSeriesList.Add(ln);
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
                                    median.Add(decimal.Parse(dr[cc].ToString()));
                                }
                                dt.Rows[i].SetField<decimal>(dc, MathUtils.Median(median));
                            }
                            this.dt.AcceptChanges();

                            ln.Column = this.dt.Columns.Count - 2;
                            this.GviLineSeriesList.Add(ln);
                            break;
                        }
                    default:
                        {
                            break;
                        }




                }
            }



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
                bool? s = value as bool?;
                ViewState["GviIsStacked"] = s;
            }
        }

        [DataMember(Name = "series")]
        public ComboChartLineSeriesList GviLineSeriesList
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
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.AREACHART);
            output.Write(Text);
        }

        public override string ToString()
        {
            List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
            myconverters.Add(new CustomConvertersColorToRGB());
            myconverters.Add(new CustomConvertersAxis());
            myconverters.Add(new CustomConvertersLegend());
            myconverters.Add(new CustomConverterEnum());
            myconverters.Add(new CustomConverterTrippleStateBool());
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
