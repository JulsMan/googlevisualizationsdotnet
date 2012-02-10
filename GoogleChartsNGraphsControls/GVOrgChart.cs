using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("GviShowTip")]
    [ToolboxData("<{0}:GVOrgChart runat=server></{0}:GVOrgChart>")]
    [ToolboxBitmap(typeof(GVOrgChart))]
    public class GVOrgChart : BaseWebControl
    {

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"Determines if double click will collapse a node.")]
        [DefaultValue(false)]
        public bool? GviAllowCollapse
        {
            get
            {
                bool? s = (bool?)ViewState["GviAllowCollapse"];
                return s;
            }

            set
            {
                ViewState["GviAllowCollapse"] = value;
            }
        }


        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("If set to true, names that includes HTML tags will be rendered as HTML.")]
        [DefaultValue(false)]
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
        [Description("A class name to assign to node elements. Apply CSS to this class name to specify colors or styles for the chart elements.")]
        [DefaultValue("")]
        public string GviNodeClass
        {
            get
            {
                string s = (string)ViewState["GviNodeClass"];
                return s;
            }

            set
            {
                ViewState["GviNodeClass"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("A class name to assign to selected node elements. Apply CSS to this class name to specify colors or styles for selected chart elements.")]
        [DefaultValue("")]
        public string GviSelectedNodeClass
        {
            get
            {
                string s = (string)ViewState["GviSelectedNodeClass"];
                return s;
            }

            set
            {
                ViewState["GviSelectedNodeClass"] = value;
            }
        }

        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description("'small', 'medium' or 'large'")]
        [DefaultValue("")]
        public string GviSize
        {
            get
            {
                string s = (string)ViewState["GviSize"];
                return s;
            }

            set
            {
                ViewState["GviSize"] = value;
            }
        }

        [GviEventOption("collapse")]
        [Bindable(true)]
        [Category("GoogleEvents")]
        [Description(@"Event triggered when allowCollapse is set to true and the user double clicks on a node with children. 
            collapsed - A boolean indicating whether this is a 'collapse' or 'expand' event.
            row - The zero-based index of the row in the data table, corresponding to the node being clicked.")]
        [DefaultValue("")]
        public string GviOnCollapse
        {
            get
            {
                string s = (string)ViewState["GviOnCollapse"];
                return s;
            }

            set
            {
                ViewState["GviOnCollapse"] = value;
            }
        }

        [GviEventOption("select")]
        [Bindable(true)]
        [Category("GoogleEvents")]
        [Description(@"Standard select event.")]
        [DefaultValue("")]
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

        [GviEventOption("onmouseover")]
        [Bindable(true)]
        [Category("GoogleEvents")]
        [Description(@"Triggered when the user hovers over a specific row.	row - The zero-based index of the row in the data table, corresponding to the node being moused over.")]
        [DefaultValue("")]
        public string GviOnMouseOver
        {
            get
            {
                string s = (string)ViewState["GviOnMouseOver"];
                return s;
            }

            set
            {
                ViewState["GviOnMouseOver"] = value;
            }
        }

        [GviEventOption("onmouseout")]
        [Bindable(true)]
        [Category("GoogleEvents")]
        [Description(@"Triggered when the user hovers out of a row.	row - The zero-based index of the row in the data table, corresponding to the node being moused out from.")]
        [DefaultValue("")]
        public string GviOnMouseOut
        {
            get
            {
                string s = (string)ViewState["GviOnMouseOut"];
                return s;
            }

            set
            {
                ViewState["GviOnMouseOut"] = value;
            }
        }

        [GviEventOption("ready")]
        [Bindable(true)]
        [Category("GoogleEvents")]
        [Description(@"The chart is ready for external method calls. If you want to interact with the chart, and call methods after you draw it, you should set up a listener for this event before you call the draw method, and call the methods only after the event is fired.")]
        [DefaultValue("")]
        public string GviOnReady
        {
            get
            {
                string s = (string)ViewState["GviOnReady"];
                return s;
            }

            set
            {
                ViewState["GviOnReady"] = value;
            }
        }


        /********************************************************
         Data Format
            A table with three string string columns, where each row represents a node in the orgchart. Here are the three columns:
            Column 0 - The node ID. It should be unique among all nodes, and can include any characters, including spaces. This is shown on the node. You can specify a formatted value to show on the chart instead, but the unformatted value is still used as the ID.
            Column 1 - [optional] The ID of the parent node. This should be the unformatted value from column 0 of another row. Leave unspecified for a root node.
            Column 2 - [optional] Tool-tip text to show, when a user hovers over this node.
            Each node can have zero or one parent node, and zero or more child nodes.
        *********************************************************/
        public void ChartData(string Name, string Parent, string ToolTip)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(String));
                this.dt.Columns.Add("Parent", typeof(String));
                this.dt.Columns.Add("Tooltip", typeof(String));
            }
            this.dt.Rows.Add(new object[] { Name, Parent, ToolTip });
        }
        public void ChartData(string Id, string Template, string ParentId, string ToolTip)
        {
            if ((this.dt == null) || (this.dt.Columns.Count == 0))
            {
                this.GviAllowHtml = true;       // turn on html cause your using a template!
                this.dt = new DataTable();
                this.dt.Columns.Add("Name", typeof(Object));
                this.dt.Columns.Add("Parent", typeof(String));
                this.dt.Columns.Add("Tooltip", typeof(String));
            }

            string foo = string.Format("{{ v:'{0}', f:'{1}' }}", Id, Template);
            this.dt.Rows.Add(new object[] 
            { 
                foo, 
                ParentId, 
                ToolTip 
            });
        }
        public void ChartData(params string[] data)
        {
            if (data.Length == 3)
                ChartData(data[0], data[1], data[2]);
            else if (data.Length == 4)
                ChartData(data[0], data[1], data[2], data[3]);
            else
                throw new Exception("OrgChart Data Validation Exception!");
        }
       
        protected override void RenderContents(HtmlTextWriter output)
        {
            this.gvi.RegisterGVIScriptsEx(this, this.dt, BaseGVI.GOOGLECHART.ORGANIZATIONCHART);
            output.Write(Text);
        }

    }
}
