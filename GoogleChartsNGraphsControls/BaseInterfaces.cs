using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace GoogleChartsNGraphsControls
{
    interface IsStackable
    {
        [GviConfigOption]
        [Bindable(true)]
        [Category("GoogleOptions")]
        [Description(@"If set to true, bar values are stacked (accumulated).")]
        [DefaultValue(false)]
        [DataMember(Name = "isStacked", EmitDefaultValue = true, IsRequired = false)]
        bool? GviIsStacked { get; set; }
    }

    interface HasTrendLines
    {
        TrendLine[] GviTrendLine { get; set; }
    }

    interface HasIntervals
    {
        Interval[] GviIntervals { get; set; }
    }
}
