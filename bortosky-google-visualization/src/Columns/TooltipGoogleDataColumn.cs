using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Bortosky.Google.Visualization.Columns;
namespace Bortosky.Google.Visualization.Columns
{
    internal class TooltipGoogleDataColumn : GoogleDataColumn
    {

        /// 
        /// <param name="column"></param>
        internal TooltipGoogleDataColumn(DataColumn column)
            : base(column)
        {

        }

        /// 
        /// <param name="row"></param>
        protected internal override string SerializedValue(DataRow row)
        {

            return string.Format("\"{0}\"", row[subjectColumn].ToString().Replace("\"", "\\\""));
        }

        protected internal override string GoogleDataType
        {
            get
            {
                return "string";
            }
        }

    }//end StringGoogleDataColumn

}//end namespace Columns