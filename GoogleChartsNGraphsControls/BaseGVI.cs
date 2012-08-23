using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

// [assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
namespace GoogleChartsNGraphsControls
{
    
    public class BaseGVI
    {
        
        public static bool REGISTER_GOOGLE_API_JS = false;
        public static bool USING_EXT_DATASTORE = false;

        
        public enum GOOGLECHART
        {
            AREACHART, TIMELINE, GEOMAP, BARCHART,
            COLUMNCHART, GAUGE, LINECHART, MAP,
            MOTIONCHART, ORGANIZATIONCHART, PIECHART,
            SPARKLINE, WORDCLOUD, SCATTERCHART, TABLEARROW, TABLEBAR,
            CANDLESTICK, COMBO
        }

        #region Formatter - for use with the IGoogleFormatter only
        private static string formatjs = "var formatter = new google.visualization.{Formatter}({FormatterParams}); formatter.format(data, {FormatColumn});";
        #endregion

        #region JSCode
        /// <summary>
        /// Old ... trying to retire this method ... the data is outputted as JSON and is not 
        /// easily debugged or matching that on the Google Vis site
        /// </summary>

        private static string jscode3 =
       @"

        /********************************************************************************
        *      GoogleVisualizationControls.NET {{ver}}
        *      http://code.google.com/p/googlevisualizationsdotnet/ 
        *      Visualization: {3} 
        *      Div Element: {0}
        *********************************************************************************/
        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
        google.setOnLoadCallback( draw_{0} );
        var chart_{0} = undefined;
        function draw_{0}() {{
                var container = document.getElementById('{0}');
                var chart = new google.visualization.{3}(container);

                var data = __DATATABLE__;
       
       
         
       /********* Formatter Hooks: your function will be called before render  ********/
                chart.formatters = function(chart,data){{
                    /*FORMATTERS*/
                }}
       /********* View Hooks: DataTables are placed in a View and invoke your functions before going to render ********/
                chart.formatView = function(chart,view){{
                    /*VIEW_FUNCTIONS*/
                }}
 
       /********* Extended Functions **********************/
                chart.reload = function(args, url)
                {{
                    if (url == undefined || url == null){{
                        url = '{QueryString}';
                    }}
                    m_SendAndDraw(container, chart, url, args)
                }};
                chart.load = function(data)
                {{
                    m_JustDraw(container, chart, data);
                }};                
                chart.format = function(data)
                {{
                    {formatter}
                }};

        /********* User Defined Functions **********************/
                {4}

        /********* Extended Params    **********************/
                chart.opts = {1};
                chart.container = container;
                
       /********* Save Chart Into DOM **********************/
                chart_{0} = chart;

       /********* Init Chart Load     **********************/
                chart.load(data);
            }}
";


//        private static string jscode =
//        @"
//
//        /********************************************************************************
//        *      GoogleVisualizationControls for .NET - by Julian King
//        *      Visualization: {3} 
//        *      Div Element: {0}
//        *********************************************************************************/
//        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
//        google.setOnLoadCallback(draw_{0});
//        function draw_{0}() {{
//                var data = new google.visualization.DataTable(chart_{0});
//                var chart = new google.visualization.{3}(document.getElementById('{0}'));
//                chart.draw(data, {1});
//            }}
//";

//    private static string jscode2 =
//        @"
//
//        /********************************************************************************
//        *      GoogleVisualizationControls.NET {{ver}}
//        *      http://code.google.com/p/googlevisualizationsdotnet/ 
//        *      Visualization: {3} 
//        *      Div Element: {0}
//        *********************************************************************************/
//        var chart_{0} = undefined;
//        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
//        google.setOnLoadCallback( draw_{0} );
//        var regEvts_{0} = function(chart) {{
//            {4}
//        }};
//        function draw_{0}() {{
//                var data = data_{0}();
//                var chart = new google.visualization.{3}(document.getElementById('{0}'));
//                regEvts_{0}(chart);
//                chart.draw(data, {1});
//                chart_{0} = chart;
//            }}
//";





//    private static string jscode_orig =
//    @"
//
//        /********************************************************************************
//        *      GoogleVisualizationControls for .NET - by Julian King
//        *      Visualization: {3} 
//        *      Div Element: {0}
//        *********************************************************************************/
//        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
//        google.setOnLoadCallback(draw_{0});
//        var regEvts_{0} = function(chart) {{
//            {4}
//        }};
//        function draw_{0}() {{
//                var data = chart_{0}();
//                var chart = new google.visualization.{3}(document.getElementById('{0}'));
//                regEvts_{0}(chart);
//                chart.draw(data, {1});
//            }}
//";
        #endregion

        private static readonly Dictionary<GOOGLECHART, string[]> dic = new Dictionary<GOOGLECHART, string[]>();
        private DataTable dt = new DataTable();
        public BaseGVI()
        {
            if (dic.Count == 0)
            {
                dic.Add(GOOGLECHART.AREACHART, new string[] { "corechart", "AreaChart" });
                dic.Add(GOOGLECHART.TIMELINE, new string[] { "annotatedtimeline", "AnnotatedTimeLine" });
                dic.Add(GOOGLECHART.GEOMAP, new string[] { "geomap", "GeoMap" });
                dic.Add(GOOGLECHART.BARCHART, new string[] { "corechart", "BarChart" });
                dic.Add(GOOGLECHART.COLUMNCHART, new string[] { "corechart", "ColumnChart" });
                dic.Add(GOOGLECHART.GAUGE, new string[] { "gauge", "Gauge" });
                dic.Add(GOOGLECHART.LINECHART, new string[] { "corechart", "LineChart" });
                dic.Add(GOOGLECHART.MAP, new string[] { "map", "Map" });
                dic.Add(GOOGLECHART.MOTIONCHART, new string[] { "motionchart", "MotionChart" });
                dic.Add(GOOGLECHART.ORGANIZATIONCHART, new string[] { "orgchart", "OrgChart" });
                dic.Add(GOOGLECHART.PIECHART, new string[] { "corechart", "PieChart" });
                dic.Add(GOOGLECHART.SPARKLINE, new string[] { "imagesparkline", "ImageSparkLine" });
                dic.Add(GOOGLECHART.SCATTERCHART, new string[] { "corechart", "ScatterChart" });
                dic.Add(GOOGLECHART.TABLEARROW, new string[] { "table", "Table" });
                dic.Add(GOOGLECHART.TABLEBAR, new string[] { "table", "Table" });
                dic.Add(GOOGLECHART.CANDLESTICK, new string[] { "candlestickchart", "CandlestickChart" });
                dic.Add(GOOGLECHART.COMBO, new string[] { "combochart", "ComboChart" });
            }
        }

        
        /// <summary>
        /// Trying to use this option from here out!
        /// </summary>
        /// <param name="PageControl"></param>
        /// <param name="dt"></param>
        /// <param name="CHARTTYPE"></param>
        internal void RegisterGVIScriptsEx(BaseWebControl PageControl, DataTable dt, GOOGLECHART CHARTTYPE)
        {
            string JAVASCRIPT = jscode3;
            string options,formatter= string.Empty;
            List<string> events = RenderGVIEvents(PageControl);
           

            if (PageControl is IGoogleTableFormatterControl)
                formatter = RenderFormatter((IGoogleTableFormatterControl)PageControl);


            //JAVASCRIPT = JAVASCRIPT.Replace("__UDF__", string.Join("\n", events.ToArray()));
            

            JAVASCRIPT = JAVASCRIPT.Replace("{formatter}", formatter);
            if (!string.IsNullOrEmpty(PageControl.QueryString) && PageControl.QueryString.StartsWith("~"))
            {
                PageControl.QueryString = PageControl.Page.ResolveUrl(PageControl.QueryString);
                JAVASCRIPT = JAVASCRIPT.Replace("{QueryString}", PageControl.QueryString);
            }
            else
            {
                JAVASCRIPT = JAVASCRIPT.Replace("{QueryString}", PageControl.QueryString);
            }


            
            // Check if manual override for Chart option is in effect
            if ((PageControl.GviOptionsOverride != null) && (!string.IsNullOrEmpty(PageControl.GviOptionsOverride.ToString())))
                options = PageControl.GviOptionsOverride.ToString();
            else
                options = RenderGVIConfigOptions(PageControl);
            

            // the name of the control being bound and over-written
            string ctlid = PageControl.ClientID;
            if (!string.IsNullOrEmpty(PageControl.OverrideElementId))
                ctlid = PageControl.OverrideElementId;

            // interpolate the options into the canned Javascript
            string optionsJscode = string.Format(JAVASCRIPT, ctlid, options, dic[CHARTTYPE].FirstOrDefault(), dic[CHARTTYPE].LastOrDefault(), string.Join("\n",events.ToArray()));
            
            // add version information onto each ChartJavascript
            string build = string.Format("v{0}.{1}.{2}.{3}",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major, 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.MajorRevision,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.MinorRevision);
            optionsJscode = optionsJscode.Replace("{ver}", build);


            // load the datatable...
            if (dt == null)
                throw new Exception(string.Format("Unable to create visualization '{0}' with an empty DataTable ", this.GetType().FullName));
            Bortosky.Google.Visualization.GoogleDataTable gdt = new Bortosky.Google.Visualization.GoogleDataTable(dt);
            optionsJscode = optionsJscode.Replace("__DATATABLE__", gdt.GetJson());

            /*
             * This allows you to manipulate the data 
             *  var formatter = new google.visualization.NumberFormat({prefix: '$'});
             *  formatter.format(data, 1); // Apply formatter to second column
             */
            if (!string.IsNullOrEmpty(PageControl.GviFormatterHook))
                optionsJscode = optionsJscode.Replace("/*FORMATTERS*/", string.Format("{0}(chart, data);", PageControl.GviFormatterHook));

            PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "function_" + ctlid, optionsJscode, true);

            
            //string datatableoutput = TransformDataTable.ToGoogleDataTable(dt);
            //PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "vis_" + ctlid, string.Format("var data_{0} = function() {{ {1} }}", ctlid, datatableoutput), true);

        }


        internal List<string> RenderGVIEvents(WebControl PageControl)
        {
            List<string> eventsList = new List<string>();
            System.Reflection.PropertyInfo[] props = PageControl.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                GviEventOption option = prop.GetCustomAttributes(typeof(GviEventOption), false)
                .Cast<GviEventOption>().FirstOrDefault();

                if (option == null) continue;

                object value = prop.GetValue(PageControl,null);
                
                if ((value == null) || (string.IsNullOrEmpty(value.ToString()))) continue;

                string foo = string.Format("google.visualization.events.addListener(chart, '{0}', function(o,a,b,c) {{ {1}(chart,a,b,c); }} );", option.EventName, value);
                foo = foo.Replace(";;", ";");
                eventsList.Add(foo);
            }

            return eventsList;
        }
        /// <summary>
        /// Renders a JSON string of all the config options.
        /// </summary>
        /// <param name="PageControl"></param>
        /// <returns></returns>
        internal string RenderGVIConfigOptions(WebControl PageControl)
        {
            return PageControl.ToString();
        }


        internal string RenderFormatter(IGoogleTableFormatterControl PageControl)
        {
            if (PageControl == null) return string.Empty;

            List<string> lst = new List<string>();
            foreach (var f in PageControl.GviFormatter.ToArray())
            {
                string fmtstr = BaseGVI.formatjs;
                // add the Formatter prop
                fmtstr = fmtstr.Replace("{Formatter}", f.ToString());
                fmtstr = fmtstr.Replace("{FormatColumn}", f.GviFormatColumn.ToString());
                fmtstr = fmtstr.Replace("{FormatterParams}", f.FormatterParams);
                //fmtstr = System.Text.RegularExpressions.Regex.Replace(fmtstr, "{\w}", "");
                lst.Add(fmtstr);
            }

            return string.Join(" \n", lst.ToArray());
        }



    }

    
}
