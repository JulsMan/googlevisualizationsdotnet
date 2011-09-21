using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Reflection;
using System.Security.Cryptography;
using System.Collections;
using System.Web.Profile;
using System.Data;



namespace GoogleChartsNGraphsControls.GVI
{
    
    /*
     * Example:
     * google.visualization.Query.setResponse(
     *  {
     *  "version":"0.6",
     *  "reqId":"1",
     *  "status":"warning",
     *  "warnings":[{"reason":"data_truncated","message":"Retrieved data was truncated","detailed_message":"Data has been truncated due to userrequest (LIMIT in query)"}],
     *  "sig":"182338197",
     *  "table":{"cols":[{"id":"A","label":"","type":"string","pattern":""},{"id":"B","label":"","type":"string","pattern":""}],"rows":[{"c":[{"v":"Bill"},{"v":"Eric"}]},{"c":[{"v":"Mary"},{"v":"Eric"}]},{"c":[{"v":"Eric"},{"v":"Joe"}]}]}
     *  });
     *  
     * 
     * A set of colon-delimited key/value pairs for standard or custom parameters. Pairs are separated by semicolons. Here is a list of the standard parameters defined by the Visualization protocol: 
     * reqId - [Required in request; Data source must handle] A numeric identifier for this request. This is used so that if a client sends multiple requests before receiving a response, the data source can identify the response with the proper request. Send this value back in the response.
     * version - [Optional in request; Data source must handle] The version number of the Google Visualization protocol. Current version is 0.6. If not sent, assume the latest version.
     * sig - [Optional in request; Optional for data source to handle] A hash of the DataTable sent to this client in any previous requests to this data source. This is an optimization to avoid sending identical data to a client twice. See Optimizing Your Request below for information about how to use this.
     * out - [Optional in request; Data source must handle] A string describing the format for the returned data. It can be any of the following values:
            json - [Default value] A JSON response string (described below).
            html - A basic HTML table with rows and columns. If this is used, the only thing that should be returned is an HTML table with the data; this is useful for debugging, as described in the Response Format section below.
            csv - Comma-separated values. If this is used, the only thing returned is a CSV data string. You can request a custom name for the file in the response headers by specifying a outFileName parameter.
            tsv-excel - Similar to csv, but using tabs instead of commas, and all data is utf-16 encoded.
            Note that the only data type that a chart built on the Google Visualization API will ever request is json. See Response Format below for details on each type.
     * responseHandler - [Optional in request; Data source must handle] The string name of the JavaScript handling function on the client page that will be called with the response. If not included in the request, the value is "google.visualization.Query.setResponse". This will be sent back as part of the response; see Response Format below to learn how.
     * outFileName - [Optional in request; Optional for data source to handle] If you specify out:csv or out:tsv-excel, you can optionally request the file name specified here. Example: outFileName=results.csv.
        Example: tqx=version:0.6;reqId:1;sig:5277771;out:json; responseHandler:myQueryHandler
     * 
     */
    [DataContract(Name="google.visualization.Query.setResponse")]
    public class GoogleQueryResponseStruct
    {
        private const string PROTOCOL_VERSION = "0.6";
        private Dictionary<string, object> _table = null;
        public GoogleQueryResponseStruct() 
        { 
            this.version = PROTOCOL_VERSION;
            this.reqId = "-1";
            this._table = new Dictionary<string, object>();
        }
        public GoogleQueryResponseStruct(HttpRequest req): this()
        {
            
            assignRequestId(req);
        }

        [DataMember(Name="version")]
        public string version { get; set; }

        [DataMember(Name="reqId",IsRequired=true)]
        public string reqId { get; set; }

        [DataMember(Name="status")]
        public string status { get; set; }

        [DataMember(Name="warnings")]
        public string[] warnings { get; set; }

        [DataMember(Name="sig")]
        public string sig { get; set; }

        [DataMember(Name="table")]
        public object table { get; private set; }
        public void SetTable(DataTable data)
        {
            var q = new Bortosky.Google.Visualization.GoogleDataTable(data);
            this.table = q.GetJson();
        }

        private void assignRequestId(HttpRequest req)
        {
             System.Text.RegularExpressions.Regex caprid = new System.Text.RegularExpressions.Regex(@"reqId:\d{1,9}",
                System.Text.RegularExpressions.RegexOptions.Compiled);
            string reqId = string.IsNullOrEmpty(req.Params["tqx"]) ? "reqId:-2;" : req.Params["tqx"];
            System.Text.RegularExpressions.Match m = caprid.Match(reqId);
            if (m.Success)
                this.reqId = m.Value.Replace("reqId:","");
            else
                this.reqId = "-1";
        }

    }




    
}
