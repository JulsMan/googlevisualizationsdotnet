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
    }
}
