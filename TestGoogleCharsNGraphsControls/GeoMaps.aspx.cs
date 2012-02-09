using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace TestGoogleCharsNGraphsControls
{
    public partial class GeoBug : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            System.Data.DataTable world = new System.Data.DataTable("World Population");
            world.Columns.AddRange(new System.Data.DataColumn[] {
                new System.Data.DataColumn("Country",typeof(string)), 
                new System.Data.DataColumn("Population",typeof(int))
            });
            world.Rows.Add(new object[] { "Germany", 200 });
            world.Rows.Add(new object[] { "United States", 350 });
            world.Rows.Add(new object[] { "Brazil", 250 });
            world.Rows.Add(new object[] { "Canada", 75 });
            world.Rows.Add(new object[] { "France", 290 });
            world.Rows.Add(new object[] { "Russia", 700 });
            world.Rows.Add(new object[] { "China", 1300 });
            world.Rows.Add(new object[] { "India", 1000 });

            this.GVGeoMap1.GviRegion = GoogleChartsNGraphsControls.MapRegion.World;
            this.GVGeoMap1.GviDisplayMode = GoogleChartsNGraphsControls.MapDisplayModes.Regions;
            this.GVGeoMap1.GviColors = new Color?[] { Color.Blue, Color.Cornsilk, Color.DarkMagenta, Color.DarkTurquoise, Color.FloralWhite };
            this.GVGeoMap1.DataSource = world;



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
