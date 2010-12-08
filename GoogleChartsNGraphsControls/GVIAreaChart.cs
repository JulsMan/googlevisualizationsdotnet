using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Security.Permissions;

namespace GoogleChartsNGraphsControls
{
    [DefaultProperty("Title")]
    [ToolboxData("<{0}:AreaChartLayout runat=server></{0}:AreaChartLayout>")]
    [ToolboxBitmap(@"C:\Documents and Settings\KINGJ5\My Documents\Visual Studio 2008\Projects\GoogleChartsNGraphsControls\GoogleChartsNGraphsControls\icons\map.bmp")]
    public class GVIAreaChart : WebControl
    {
        private DataTable dt = new DataTable();
        private AreaChartLayout acl = new AreaChartLayout();

        #region GenericGVIControl Members
        public DataTable ChartDataTable
        {
            get
            {
                if (acl.Validate())
                    return acl.ToDataTable();
                return dt;
                   
            }
            set
            {
                this.dt = value;
            }
        }


        #endregion

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }


        [Category("Appearance")]
        [Description("Title appearing above or below the chart chart control")]
        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        public virtual string Title
        {
            get
            {
                String s = (String)ViewState["Title"];
                return (s == null) ? string.Empty : s;
            }

            set
            {
                ViewState["Title"] = value;
            }
        }


        #region ManagedData Loading...
        public void SetXAxis(PlotLine plotX)
        {
            this.acl.XAxis = plotX;
        }
        public void LoadLine(PlotLine line)
        {
            this.acl.AddPlotLine(line);
        }
        public void LoadLine(string Caption, string[] Points)
        {
            PlotLine line = new PlotLine(Caption);
            line.Points = Points;
            this.acl.AddPlotLine(line);
        }
        public void LoadLine(string Caption, Decimal[] Points)
        {
            PlotLine line = new PlotLine(Caption);
            line.Points = Points.Cast<object>().ToArray();
            this.acl.AddPlotLine(line);
        }
        public void LoadLine(string Caption, int[] Points)
        {
            PlotLine line =
                new PlotLine(Caption);
            line.Points = Points.Cast<object>().ToArray();
            this.acl.AddPlotLine(line);
        }
        public void LoadLine(string Caption, DateTime[] Points)
        {
            PlotLine line =
                new PlotLine(Caption);
            line.Points = Points.Cast<object>().ToArray();
            this.acl.AddPlotLine(line);
        }
        #endregion

        protected override void RenderContents(HtmlTextWriter output)
        {
            List<string> attrs = new List<string>();
            attrs.Add(string.Format("id={0}", this.ClientID));

            System.Reflection.PropertyInfo[] props = 
                this.GetType().GetProperties(System.Reflection.BindingFlags.Public);
            
            foreach (System.Reflection.PropertyInfo prop in props)
                attrs.Add(string.Format("{0}={1}", prop.Name, prop.GetValue(this, null)));

            output.Write(string.Format("<div {0}> </div>",
                string.Join(" ",attrs.ToArray())));
        }




    }
}
