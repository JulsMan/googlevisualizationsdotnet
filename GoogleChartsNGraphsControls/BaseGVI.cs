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
        
        public enum GOOGLECHART
        {
            AREACHART, TIMELINE, GEOMAP, BARCHART,
            COLUMNCHART, GAUGE, LINECHART, MAP,
            MOTIONCHART, ORGANIZATIONCHART, PIECHART,
            SPARKLINE, WORDCLOUD, SCATTERCHART
        }

        #region JSCode
        /// <summary>
        /// Old ... trying to retire this method ... the data is outputted as JSON and is not 
        /// easily debugged or matching that on the Google Vis site
        /// </summary>
        private static string jscode =
        @"

        /********************************************************************************
        *      GoogleVisualizationControls for .NET - by Julian King
        *      Visualization: {3} 
        *      Div Element: {0}
        *********************************************************************************/
        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
        google.setOnLoadCallback(draw_{0});
        function draw_{0}() {{
                var data = new google.visualization.DataTable(chart_{0});
                var chart = new google.visualization.{3}(document.getElementById('{0}'));
                chart.draw(data, {1});
            }}
";

    private static string jscode2 =
        @"

        /********************************************************************************
        *      GoogleVisualizationControls.NET {{ver}}
        *      http://code.google.com/p/googlevisualizationsdotnet/ 
        *      Visualization: {3} 
        *      Div Element: {0}
        *********************************************************************************/
        var chart_{0} = undefined;
        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
        google.setOnLoadCallback( draw_{0} );
        var regEvts_{0} = function(chart) {{
            {4}
        }};
        function draw_{0}() {{
                var data = data_{0}();
                var chart = new google.visualization.{3}(document.getElementById('{0}'));
                regEvts_{0}(chart);
                chart.draw(data, {1});
                chart_{0} = chart;
            }}
";





    private static string jscode_orig =
    @"

        /********************************************************************************
        *      GoogleVisualizationControls for .NET - by Julian King
        *      Visualization: {3} 
        *      Div Element: {0}
        *********************************************************************************/
        google.load('visualization', '1', {{ 'packages': ['{2}'] }});
        google.setOnLoadCallback(draw_{0});
        var regEvts_{0} = function(chart) {{
            {4}
        }};
        function draw_{0}() {{
                var data = chart_{0}();
                var chart = new google.visualization.{3}(document.getElementById('{0}'));
                regEvts_{0}(chart);
                chart.draw(data, {1});
            }}
";
        #endregion

        private Dictionary<GOOGLECHART, string[]> dic = new Dictionary<GOOGLECHART, string[]>();
        private DataTable dt = new DataTable();
        public BaseGVI()
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
        }

        
        /// <summary>
        /// Trying to use this option from here out!
        /// </summary>
        /// <param name="PageControl"></param>
        /// <param name="dt"></param>
        /// <param name="CHARTTYPE"></param>
        internal void RegisterGVIScriptsEx(BaseWebControl PageControl, DataTable dt, GOOGLECHART CHARTTYPE)
        {
            if (!REGISTER_GOOGLE_API_JS)
            {
                PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "REGISTER_GOOGLE_API_JS", @"<script type='text/javascript' src='http://www.google.com/jsapi'></script>");
                REGISTER_GOOGLE_API_JS = true;
            }

            string events = RenderGVIEvents(PageControl);
            string options = RenderGVIConfigOptions(PageControl);
            if ((PageControl.GviOptionsOverride != null) && (!string.IsNullOrEmpty(PageControl.GviOptionsOverride.ToString())))
            {
                // the override switch is in play ... use the json struct here to override the manually set items...
                options = PageControl.GviOptionsOverride.ToString();
            }
            // base.OnPreRender(e);
            string optionsJscode = string.Format(jscode2, PageControl.ClientID, options, dic[CHARTTYPE].FirstOrDefault(), dic[CHARTTYPE].LastOrDefault(), events);
            string build = string.Format("v{0}.{1}.{2}.{3}",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major, 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.MajorRevision,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.MinorRevision);
            optionsJscode = optionsJscode.Replace("{ver}", build);  
            
            PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "function_" + PageControl.ClientID, optionsJscode, true);

            if (this.dt == null)
                throw new Exception(string.Format("Unable to create visualization '{0}' with an empty DataTable ", this.GetType().FullName));

            //Bortosky.Google.Visualization.GoogleDataTable gdt = new Bortosky.Google.Visualization.GoogleDataTable(dt);
            string datatableoutput = TransformDataTable.ToGoogleDataTable(dt);
            PageControl.Page.ClientScript.RegisterStartupScript(this.GetType(), "vis_" + PageControl.ClientID, string.Format("var data_{0} = function() {{ {1} }}", PageControl.ClientID, datatableoutput), true);

        }


        internal string RenderGVIEvents(WebControl PageControl)
        {
            List<string> eventsList = new List<string>();
            System.Reflection.PropertyInfo[] props = PageControl.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                GviEventOption option = prop.GetCustomAttributes(typeof(GviEventOption), false)
                .Cast<GviEventOption>().FirstOrDefault();

                if (option == null) continue;

                object value = prop.GetValue(PageControl,null);
                
                if (value == null) continue;

                string foo = string.Format("chart.{0} = {1};", option.EventName, value);
                foo = foo.Replace(";;", ";");
                eventsList.Add(foo);
            }

            return string.Join(Environment.NewLine, eventsList.ToArray());
        }
        /// <summary>
        /// Renders a JSON string of all the config options.
        /// </summary>
        /// <param name="PageControl"></param>
        /// <returns></returns>
        internal string RenderGVIConfigOptions(WebControl PageControl)
        {
            List<string> optionsList = new List<string>();

            System.Reflection.PropertyInfo[] props = PageControl.GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo prop in props)
            {
                GviConfigOption option = prop.GetCustomAttributes(typeof(GviConfigOption), false)
                .Cast<GviConfigOption>().FirstOrDefault();

                if (option == null) continue;
                
                object val = prop.GetValue(PageControl, null); 

                if (val == null) continue;

                // convert any ' to \'
                if (val is string)
                    val = val.ToString().Replace("'", @"\'");

                if (prop.PropertyType == typeof(string))
                {
                    if (!string.IsNullOrEmpty(val.ToString()))
                        optionsList.Add(string.Format("'{0}':'{1}'", prop.Name.GVINameParse(), val));
                }
                else if (prop.PropertyType == typeof(bool?))
                {
                    optionsList.Add(string.Format("'{0}':{1}", prop.Name.GVINameParse(), val.ToString().ToLower()));
                }
                else if (prop.PropertyType == typeof(Color?))
                {
                    optionsList.Add(string.Format("'{0}':'{1}'", prop.Name.GVINameParse(), RGBtoHex((Color)val)));
                }
                else if (prop.PropertyType == typeof(Color?[]))
                {
                    string rgb = RGBtoHex((Color?[]) val);
                    optionsList.Add(string.Format("'{0}':{1}", prop.Name.GVINameParse(), RGBtoHex((Color)val)));
                }
                else if (prop.PropertyType == typeof(int?[]))
                {
                    List<int> lst = new List<int>();
                    foreach (int? i in (int?[]) val)
                        if (i != null)
                            lst.Add((int)i);
                    optionsList.Add(string.Format("'{0}':{1}", prop.Name.GVINameParse(), 
                        string.Format("[ {0} ]",string.Join(",",lst.Select( s => s.ToString()).ToArray()))));
                }
                else
                    optionsList.Add(string.Format("{0}:{1}", prop.Name.GVINameParse(), val.ToString()));
            }

            return string.Format("{{ {0} }}", string.Join(",", optionsList.ToArray()));
        }
        internal static string RGBtoHex(System.Drawing.Color?[] c)
        {
            List<string> foo = new List<string>();
            foreach(Color? cc in c)
                if (cc != null)
                    foo.Add(RGBtoHex((Color) cc));

            return string.Format("[ {0} ]", string.Join(",",foo.ToArray()));
        }
        internal static string RGBtoHex(System.Drawing.Color c)
        {
            return RGBtoHex(c.R, c.G, c.B);
        }
        internal static string RGBtoHex(byte R, byte G, byte B)
        {
            return String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);
        }
    }

    
}
