<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoBug.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.GeoBug" %>

<%@ Register Assembly="GoogleChartsNGraphsControls" Namespace="GoogleChartsNGraphsControls"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type='text/javascript' src='http://www.google.com/jsapi'></script>
    <style>
        .sloppyCode
        {
            background-color: #FAF8CC; 
            border: dashed 1px grey; 
            text-align: left; 
            margin-left: 55px;
            padding: 16px 0px 0px 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:GVGeoMap ID="GVGeoMap2" runat="server" />
        
        <pre class="sloppyCode">
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
            this.GVGeoMap2.ChartData(projs);
        </pre>
    </div>
    
    <div>
    </div>
    </form>
</body>
</html>
