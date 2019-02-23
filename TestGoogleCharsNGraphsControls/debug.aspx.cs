using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoogleCharsNGraphsControls
{
    public partial class debug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt2 = new System.Data.DataTable("Company Sales/Expenses");
            dt2.Columns.Add("Year");
            dt2.Columns.Add("Expenses", typeof(int));
            dt2.Columns.Add("Sales", typeof(int));
            dt2.Rows.Add(new object[] { "2004", 215000, 225000 });
            dt2.Rows.Add(new object[] { "2005", 300000, 320000 });
            dt2.Rows.Add(new object[] { "2006", 326000, 356000 });
            dt2.Rows.Add(new object[] { "2007", 485000, 490000 });
            dt2.Rows.Add(new object[] { "2008", 410000, 442000 });
            dt2.Rows.Add(new object[] { "2009", 466000, 422000 });
            dt2.Rows.Add(new object[] { "2010", 480000, 435000 });

            this.GVLineChart1.DataSource = dt2;
        }
    }
}