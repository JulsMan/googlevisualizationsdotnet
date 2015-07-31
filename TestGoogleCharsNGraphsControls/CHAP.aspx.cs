using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestGoogleCharsNGraphsControls
{
    public partial class CHAP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ChapTimeline();
               
            }
        }


        private void ChapTimeline()
        {
            List<GoogleChartsNGraphsControls.CHAPTimelineEvent> lst = new List<GoogleChartsNGraphsControls.CHAPTimelineEvent>();
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015,7,1), new GoogleChartsNGraphsControls.CHAPTimelineEvent.ImgFormatContent()));
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015, 7, 3), "Ordered Pizza"));
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015, 7, 9), "Showered"));
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015, 7, 14), "Pizza Arrived"));
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015, 7, 16), new DateTime(2015, 7, 19),"Ate Pizza"));
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015, 7, 22), new DateTime(2015, 7, 23), "Watched TV"));
            lst.Add(new GoogleChartsNGraphsControls.CHAPTimelineEvent(new DateTime(2015, 7, 27), "Bed Time!"));

            this.CHAPTimeline1.ChartData(lst.ToArray());
            this.CHAPTimeline1.GviOptionsOverride = "{}";
        }
    }
}