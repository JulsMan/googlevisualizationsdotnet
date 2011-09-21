using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Bortosky.Google.Visualization;
using System.Collections.ObjectModel;

namespace TestGoogleCharsNGraphsControls
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AjaxUpdateHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.AddHeader("Content-Disposition", "inline; filename=Response.json");
            System.Data.DataTable dt = null;
            Random rand = new Random(System.Environment.TickCount);

            switch(context.Request.Params["type"])
            {
                case "column":
                {
                    dt = new System.Data.DataTable("Company Performance");
                    dt.Columns.Add("Year", typeof(string));
                    dt.Columns.Add("Sales", typeof(int));
                    dt.Columns.Add("Expenses", typeof(int));
                    dt.Rows.Add(new object[] { "2004", rand.Next(100, 1000), rand.Next(75,700) });
                    dt.Rows.Add(new object[] { "2005", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2006", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2007", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2008", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2009", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2010", rand.Next(100, 1000), rand.Next(75, 700) });
                    dt.Rows.Add(new object[] { "2011", rand.Next(100, 1000), rand.Next(75, 700) });
                    break;
                }
                default:
                {
                    dt = new System.Data.DataTable("Computer");
                        dt.Columns.AddRange(new System.Data.DataColumn[] {
                        new System.Data.DataColumn("Label",typeof(string)), 
                        new System.Data.DataColumn("Value",typeof(int))
                    });


                    dt.Rows.Add(new object[] { "Memory", rand.Next(0, 100) });
                    dt.Rows.Add(new object[] { "CPU", rand.Next(0, 100) });
                    dt.Rows.Add(new object[] { "Network", rand.Next(0, 100) });
                    break;
                }
        }

            context.Response.Write(new Bortosky.Google.Visualization.GoogleDataTable(dt).GetJson());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
