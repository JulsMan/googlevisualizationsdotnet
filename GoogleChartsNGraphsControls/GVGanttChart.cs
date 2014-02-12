using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVGanttChart runat=server></{0}:GVGanttChart>")]
    [ToolboxBitmap(typeof(GVGanttChart))]
    [DataContract]
    public class GVGanttChart : BaseWebControl, IsStackable
    {

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
       
        protected override void RenderContents(HtmlTextWriter output)
        {
            List<Color?> tmp = new List<Color?>();
            tmp.Add(this.GVIBackgroundColor == null ? Color.Transparent : this.GVIBackgroundColor);
            if (this.GviColors != null) tmp.AddRange(this.GviColors);

            this.GviIsStacked = true;
            this.GviColors = tmp.ToArray();
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, TableWithLeadTime(this.dt), BaseGVI.GOOGLECHART.BARCHART);
            output.Write(Text);
        }
        // Support for IPostBackEventHandler
        //protected override void Render(HtmlTextWriter output)
        //{
        //    RenderContents(output);
        //}

        /*
         * 
         *  We’ll use the same logic we did to get the bars for each task to align start to finish, 
         *  though now we’ll have 6 total data series, including the lead time drawn in white.  
         *  For our example, steps 1 and 2 are complete, and we are on time with step 3.  
         *  We will need to pass the following data series:
         * 
         * Lead Time (in white) : 0,3,4,10,11
         * Complete: 3,1,0,0,0
         * In Process & On Time: 0,0,6,0,0
         * In Process & Late: 0,0,0,0,0
         * Upcoming: 0,0,0,1,3
         * Other: 0,0,0,0,0 
         * 
         * 
         *  Sample Code:
            System.Data.DataTable barchart = new System.Data.DataTable("Company Performance");
            barchart.Columns.Add("Year", typeof(string));
            barchart.Columns.Add("Sales", typeof(int));
            barchart.Columns.Add("Expenses", typeof(int));
            barchart.Rows.Add(new object[] { "2004", 1000, 400 });
            barchart.Rows.Add(new object[] { "2005", 1170, 460 });
            barchart.Rows.Add(new object[] { "2006", 660, 1120 });
            barchart.Rows.Add(new object[] { "2007", 1030, 540 });
            this.GVBarChart1.GviVAxis = "{title: 'Year', titleTextStyle: {color: 'red'} }";
            this.GVBarChart1.ChartData(barchart);
         * 
         * 
         * So our Gantt chart now starts to give us some more detailed information.  
         * We’ll also add some data labels so a legend is painted.
         */
        internal static System.Data.DataTable TableWithLeadTime(System.Data.DataTable dt)
        {
            if (dt.Columns.Count > 2) throw new Exception("Gantt Charts don't support having more then 2 columns valid ie.['Date',value]");

            // test for numeric types only
            
            System.Data.DataTable dtwithlead = new System.Data.DataTable();
            dtwithlead.Columns.Add(dt.Columns[0].ColumnName, dt.Columns[0].DataType);
            dtwithlead.Columns.Add(" ",dt.Columns[1].DataType);
            dtwithlead.Columns.Add(dt.Columns[1].ColumnName, dt.Columns[1].DataType);

            int leading = 0;
            foreach(System.Data.DataRow dr in dt.Rows)
            {
                object[] tmp = new object[]{dr[0],leading,dr[1]};
                leading += int.Parse(dr[1].ToString());
                dtwithlead.Rows.Add(tmp);
            }

            return dtwithlead;
        }

        public override string ToString()
        {
            List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
            myconverters.Add(new CustomConvertersColorToRGB());
            myconverters.Add(new CustomConvertersAxis());
            myconverters.Add(new CustomConvertersLegend());
            myconverters.Add(new CustomConverterEnum());
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
