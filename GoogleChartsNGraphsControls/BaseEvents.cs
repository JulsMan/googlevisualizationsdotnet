using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleChartsNGraphsControls
{
    public class GVEventArgs : EventArgs
    {
        public string GVChartId { get; set; }
        public enum GoogleEventType { }
        public GVEventArgs() { }

    }


    public class BaseEvents
    {
        public event EventHandler ClickEvent;

    }
}
