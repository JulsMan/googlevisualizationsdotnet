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
    [ToolboxData("<{0}:CHAPTimeline runat=server></{0}:CHAPTimeline>")]
    [ToolboxBitmap(typeof(CHAPTimeline))]
    [DataContract]
    public class CHAPTimeline : BaseWebControl
    {

        [GviConfigOption]
        [GviEventOption("changed")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"The properties of an event changed. Fired after the user modified the start date or end date of an event by moving (dragging) the event in the Timeline. 
The selected row can be retrieved via the method getSelection, and new start and end data can be read in the according row in the data table. 
The changed event can be canceled by calling the method cancelChange from within the event listener. This is useful when changes need to be approved.")]
        [DataMember(Name = "changed", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnChanged
        {
            get
            {
                string s = (string)ViewState["GviOnChanged"];
                return s;
            }
            set
            {
                ViewState["GviOnChanged"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("add")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"An event is about the be added. Fired after the user has clicked the button 'Add event' and created a new event by clicking or moving an event into the Timeline. 
The selected row can be retrieved via the method getSelection, and new start and end data can be read in the according row in the data table. 
The add event can be canceled by calling the method cancelAdd from within the event listener.This is useful when additions need to be approved.")]
        [DataMember(Name = "add", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnAdd
        {
            get
            {
                string s = (string)ViewState["GviOnAdd"];
                return s;
            }
            set
            {
                ViewState["GviOnAdd"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("edit")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"An event is about to be edited. This event is fired when the user double clicks on an event. The selected row can be retrieved via the method getSelection.")]
        [DataMember(Name = "edit", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnEdit
        {
            get
            {
                string s = (string)ViewState["GviOnEdit"];
                return s;
            }
            set
            {
                ViewState["GviOnEdit"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("delete")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"An event is about to be deleted. Fired after the user clicked the 'Delete Event' button on the right of an event. 
The selected row can be retrieved via the method getSelection, and new start and end data can be read in the according row in the data table.
The delete event can be canceled by calling the method cancelDelete from within the event listener.This is useful when deletions need to be approved.")]
        [DataMember(Name = "delete", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnDelete
        {
            get
            {
                string s = (string)ViewState["GviOnDelete"];
                return s;
            }
            set
            {
                ViewState["GviOnDelete"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("rangechanged")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"Visible range has been changed. Fired once after the user has modified the visible time by moving (dragging) the timeline, or by zooming (scrolling), but not after a call to setVisibleChartRange or setRangeToCurrentTime methods. The new range can be retrieved by calling getVisibleChartRange method.")]
        [DataMember(Name = "rangechanged", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnRangeChanged
        {
            get
            {
                string s = (string)ViewState["GviOnRangeChanged"];
                return s;
            }
            set
            {
                ViewState["GviOnRangeChanged"] = value;
            }
        }

        [GviConfigOption]
        [GviEventOption("select")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"When the user clicks on an event or a cluster on the timeline, the corresponding row in the data table is selected. The visualization then fires this event. 
The selected row or cluster can be retrieved via the method getSelection.")]
        [DataMember(Name = "select", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnSelect
        {
            get
            {
                string s = (string)ViewState["GviOnSelect"];
                return s;
            }
            set
            {
                ViewState["GviOnSelect"] = value;
            }
        }


        [GviConfigOption]
        [GviEventOption("timechanged")]
        [Bindable(true)]
        [Category("Events")]
        [Description(@"The custom time bar has been changed. Fired once after the user has dragged the blue custom time bar, but not after a call to the setCustomTime method. The new custom time can be retrieved by calling getCustomTime method.")]
        [DataMember(Name = "timechanged", EmitDefaultValue = true, IsRequired = false)]
        public string GviOnTimeChanged
        {
            get
            {
                string s = (string)ViewState["GviOnTimeChanged"];
                return s;
            }
            set
            {
                ViewState["GviOnTimeChanged"] = value;
            }
        }

        private DateTime? visibleChartRangeStart
        {
            get
            {
                if (ViewState["visibleChartRangeStart"] == null)
                    return null;

                DateTime? s = (DateTime?)ViewState["visibleChartRangeStart"];
                return s;
            }
            set
            {
                ViewState["visibleChartRangeStart"] = value;
            }
        }
        private DateTime? visibleChartRangeEnd
        {
            get
            {
                if (ViewState["visibleChartRangeEnd"] == null)
                    return null;

                DateTime? s = (DateTime?)ViewState["visibleChartRangeEnd"];
                return s;
            }
            set
            {
                ViewState["visibleChartRangeEnd"] = value;
            }
        }
        public void SetVisibleChartRange(DateTime start, DateTime end)
        {
            this.visibleChartRangeStart = start;
            this.visibleChartRangeEnd = end;
        }

        public CHAPTimelineOptions TimelineOptions { get; set; }

        public void ChartData(CHAPTimelineEvent[] ListOfEvents)
        {

            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                // there always must be a date
                dt.Columns.Add("start", typeof(DateTime));
                dt.Columns.Add("end", typeof(DateTime));
                dt.Columns.Add("content");
                dt.Columns.Add("editable", typeof(bool));
                dt.Columns.Add("group");
            }


            foreach(var ee in ListOfEvents)
            {
                this.dt.Rows.Add(ee.ToRow());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType().BaseType, "REGISTER_CHAP_TIMELINE"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType().BaseType, "REGISTER_CHAP_TIMELINE",
                    Resource1.ResourceManager.GetString("timeline_min", System.Globalization.CultureInfo.CurrentCulture), true);
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType().BaseType, "REGISTER_CHAP_TIMELINE_LOCALES",
                   Resource1.ResourceManager.GetString("timeline_locales", System.Globalization.CultureInfo.CurrentCulture), true);

                 
                 this.Page.Header.Controls.Add(new LiteralControl("<style type=\"text/css\">" 
                     + Environment.NewLine 
                     + Resource1.ResourceManager.GetString("timeline", System.Globalization.CultureInfo.CurrentCulture) 
                     + Environment.NewLine + "</style>" ));


                this.Page.Header.Controls.Add(new LiteralControl("<style type=\"text/css\">"
                    + Environment.NewLine
                    + Resource1.ResourceManager.GetString("timeline_theme", System.Globalization.CultureInfo.CurrentCulture)
                    + Environment.NewLine + "</style>"));

            }

          
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            this.GviTitle = string.IsNullOrEmpty(this.GviTitle) ? this.dt.TableName : this.GviTitle;
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.CHAP_TIMELINE);
            output.Write(Text);
        }

        public override string ToString()
        {
            List<Newtonsoft.Json.JsonConverter> myconverters = new List<Newtonsoft.Json.JsonConverter>();
            //myconverters.Add(new CustomConvertersColorToRGB());
            //myconverters.Add(new CustomConvertersAxis());
            //myconverters.Add(new CustomConvertersLegend());
            //myconverters.Add(new CustomConverterEnum());
            //myconverters.Add(new CustomConverterTrendLine());

            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                Converters = myconverters
            };

            string s = string.Empty;
            s = Newtonsoft.Json.JsonConvert.SerializeObject(this.TimelineOptions, settings);
            return s;
        }
    }
}
