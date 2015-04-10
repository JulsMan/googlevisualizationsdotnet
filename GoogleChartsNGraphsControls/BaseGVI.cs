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
            AREACHART, ANNOTATEDTIMELINE, GEOMAP, BARCHART,
            COLUMNCHART, GAUGE, LINECHART, MAP,
            MOTIONCHART, ORGANIZATIONCHART, PIECHART,
            WORDCLOUD, SCATTERCHART, TABLEARROW, TABLEBAR,
            CANDLESTICK, COMBO, HISTOGRAM, DONUT, TREEMAP, TIMELINE,
            WORDTREE,
            CALENDAR, ANNOTATION, SANKEY
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
                
      

       /********* Init Chart Load     **********************/
                chart.load(data);


      /********* Update These Image Src     **********************/
                    {SETIMAGEFOR}





 /********* Save Chart Into DOM / Always Last **********************/
                chart_{0} = chart;

                

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
                dic.Add(GOOGLECHART.ANNOTATEDTIMELINE, new string[] { "annotatedtimeline", "AnnotatedTimeLine" });
                dic.Add(GOOGLECHART.GEOMAP, new string[] { "geomap", "GeoMap" });
                dic.Add(GOOGLECHART.BARCHART, new string[] { "corechart", "BarChart" });
                dic.Add(GOOGLECHART.COLUMNCHART, new string[] { "corechart", "ColumnChart" });
                dic.Add(GOOGLECHART.GAUGE, new string[] { "gauge", "Gauge" });
                dic.Add(GOOGLECHART.LINECHART, new string[] { "corechart", "LineChart" });
                dic.Add(GOOGLECHART.MAP, new string[] { "map", "Map" });
                dic.Add(GOOGLECHART.MOTIONCHART, new string[] { "motionchart", "MotionChart" });
                dic.Add(GOOGLECHART.ORGANIZATIONCHART, new string[] { "orgchart", "OrgChart" });
                dic.Add(GOOGLECHART.PIECHART, new string[] { "corechart", "PieChart" });
                //dic.Add(GOOGLECHART.SPARKLINE, new string[] { "imagesparkline", "ImageSparkLine" });
                dic.Add(GOOGLECHART.SCATTERCHART, new string[] { "corechart", "ScatterChart" });
                dic.Add(GOOGLECHART.TABLEARROW, new string[] { "table", "Table" });
                dic.Add(GOOGLECHART.TABLEBAR, new string[] { "table", "Table" });
                dic.Add(GOOGLECHART.CANDLESTICK, new string[] { "candlestickchart", "CandlestickChart" });
                dic.Add(GOOGLECHART.COMBO, new string[] { "corechart", "ComboChart" });
                dic.Add(GOOGLECHART.HISTOGRAM, new string[] { "corechart", "Histogram" });
                dic.Add(GOOGLECHART.TIMELINE, new string[] { "timeline", "Timeline" });
                dic.Add(GOOGLECHART.DONUT, new string[] { "corechart", "PieChart" });
                dic.Add(GOOGLECHART.TREEMAP, new string[] { "treemap", "TreeMap" });
                dic.Add(GOOGLECHART.CALENDAR, new string[] { "calendar", "Calendar" });
                dic.Add(GOOGLECHART.ANNOTATION, new string[] { "annotationchart", "AnnotationChart" });
                dic.Add(GOOGLECHART.SANKEY, new string[] { "sankey", "Sankey" });
                dic.Add(GOOGLECHART.WORDTREE, new string[] { "wordtree", "WordTree" });
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
            string options,formatter = string.Empty;
            string imagereplace = string.Empty;
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


            imagereplace = RenderSetImage(PageControl);
            JAVASCRIPT = JAVASCRIPT.Replace("{SETIMAGEFOR}", imagereplace);


            
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
            optionsJscode = optionsJscode.Replace("__DATATABLE__", PageControl.PostProcessData( gdt.GetJson()));

           

            /*
             * This allows you to manipulate the data 
             *  var formatter = new google.visualization.NumberFormat({prefix: '$'});
             *  formatter.format(data, 1); // Apply formatter to second column
             */
            if (!string.IsNullOrEmpty(PageControl.GviFormatterHook))
                optionsJscode = optionsJscode.Replace("/*FORMATTERS*/", string.Format("{0}(chart, data);", PageControl.GviFormatterHook));

            PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "function_" + ctlid, optionsJscode, true);

            //RenderSetImage(PageControl);
            //string datatableoutput = TransformDataTable.ToGoogleDataTable(dt);
            //PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "vis_" + ctlid, string.Format("var data_{0} = function() {{ {1} }}", ctlid, datatableoutput), true);

        }


        internal string RenderSetImage(BaseWebControl PageControl)
        {

            string REGISTERSCRIPT = string.Empty;
            if (PageControl.SetImageFor.Count() > 0)
            {
                string JSIMGFOR = "document.getElementById('{0}').setAttribute('src',chart.getImageURI());" + Environment.NewLine;
                foreach (string s in PageControl.SetImageFor)
                    REGISTERSCRIPT += string.Format(JSIMGFOR, s, PageControl.ClientID);
            }

            return REGISTERSCRIPT;
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

                string foo = string.Format("google.visualization.events.addListener(chart, '{0}', {1});", option.EventName, value);
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
            var s =  PageControl.ToString();
            //s = FixJSON(s);
            return UglyJSONAxisFix(s);
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

        /// <summary>
        /// Ugly bug, where if two Axis are placed, then the second has a '"' in front of it, remove it forefully
        /// </summary>
        /// <param name="JSON"></param>
        /// <returns></returns>
        internal static string UglyJSONAxisFix(string JSON)
        {
            //return JSON;
            string s =  JSON.Replace("}null}", "}}");
            string pattern = "\"(\\w+)\"\\s*:";
            string replacement = "$1:";
            s = System.Text.RegularExpressions.Regex.Replace(s, pattern, replacement); 
            return s;
        }
        internal static string FixJSON(string JSON)
        {
            /*
             * chart.opts = 
             * {"title":"Company Sales/Expenses","colors":['#FF0000','#008000','#0000FF','#FFA500'],
             * "animation":{"duration":1000,"easing":"out"},"hAxis":{"textPosition":"default","title":"Hoz Axis Title","slantedText":true,"viewWindowMode":"default"}};
             *
             * all options with "title": or "xxxxx": => xxxxx:
             */

            System.Text.RegularExpressions.Regex rxfix = new System.Text.RegularExpressions.Regex("\"\\w.+?\":.", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
            System.Text.RegularExpressions.MatchCollection mc =  rxfix.Matches(JSON);

            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                string replace = m.Value;
                string replacewith = string.Empty;
                // strip first '"'
                if (m.Value.StartsWith("\""))
                    replacewith = m.Value.TrimStart('"');
                if (m.Value.Contains("\":"))
                    replacewith = replacewith.Replace("\":", ":");

                JSON = JSON.Replace(replace, replacewith);

            }

            return JSON;
        }

    }

    
}
