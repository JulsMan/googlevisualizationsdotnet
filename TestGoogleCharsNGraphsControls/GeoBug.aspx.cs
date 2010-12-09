using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoogleCharsNGraphsControls
{
    public partial class GeoBug : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable projs = new System.Data.DataTable("US Projects");
            projs.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("City",typeof(string)), 
                new System.Data.DataColumn("Completion",typeof(int)),
                new System.Data.DataColumn("Comments",typeof(string)) 
            });
            projs.Rows.Add(new object[] { "Astoria, NY", 95, "Astoria: Almost Done" });
            projs.Rows.Add(new object[] { "Novato, CA", 35, "Novato: Just Starting" });
            projs.Rows.Add(new object[] { "Duvall, WA", 10, "Duvall: Just Starting" });

            this.GVGeoMap2.GviOptionsOverride = "{'region':'US','colors':[0xFF8747, 0xFFB581, 0xc06000], 'dataMode':'markers'}";
            this.GVGeoMap2.DataSource = projs;
        }
    }
}
