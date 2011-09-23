using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace TestGoogleCharsNGraphsControls
{
    // NOTE: If you change the class name "WCFTestService" here, you must also update the reference to "WCFTestService" in Web.config.
    [ServiceContract]
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class WCFTestService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "HelloWorldPOST")]
        public string HelloWorldPOST()
        {
            return "Hello World!!!";
        }

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "HelloWorldGET")]
        public string HelloWorldGET()
        {
            return "Hello World!!!";
        }



        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GVPieChart2")]
        public string GVPieChart2()
        {
            Random rand = new Random(Environment.TickCount);

            System.Data.DataTable dt = new System.Data.DataTable("Work Day");
            dt.Columns.Add("Activity");
            dt.Columns.Add("Daily Percentage", typeof(int));
            dt.Rows.Add(new object[] { "Engineering", rand.Next(1,12) });
            dt.Rows.Add(new object[] { "Programming", rand.Next(1, 12) });
            dt.Rows.Add(new object[] { "Sleeping", rand.Next(1, 12) });
            dt.Rows.Add(new object[] { "Lunch", rand.Next(1, 12) });
            dt.Rows.Add(new object[] { "Meetings", rand.Next(1, 12) });

            return new Bortosky.Google.Visualization.GoogleDataTable(dt).GetJson();       
        }

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GVScatterChart1")]
        public string GVScatterChart1()
        {
            Random rand = new Random(Environment.TickCount);

            System.Data.DataTable dt = new System.Data.DataTable("Scatter Example");
            dt.Columns.AddRange(
                new System.Data.DataColumn[]{
                    new System.Data.DataColumn("Age",typeof(int)), 
                    new System.Data.DataColumn("Weight",typeof(int))
                });
            dt.Rows.Add(new object[] { rand.Next(1, 21), rand.Next(20, 100) });
            dt.Rows.Add(new object[] { rand.Next(1, 21), rand.Next(20, 100) });
            dt.Rows.Add(new object[] { rand.Next(1, 21), rand.Next(20, 100) });
            dt.Rows.Add(new object[] { rand.Next(1, 21), rand.Next(20, 100) });
            dt.Rows.Add(new object[] { rand.Next(1, 21), rand.Next(20, 100) });
            dt.Rows.Add(new object[] { rand.Next(1, 21), rand.Next(20, 100) });

            return new Bortosky.Google.Visualization.GoogleDataTable(dt).GetJson();  
        }
    }
}
