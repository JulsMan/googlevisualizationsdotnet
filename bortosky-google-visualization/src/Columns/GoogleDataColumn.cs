/*
   Copyright 2009-2010 Gary Bortosky

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Data;


namespace Bortosky.Google.Visualization.Columns {
	/// <summary>
	/// An abstract class for emitting the DataColumn value and data type
	/// </summary>
    
    
	internal abstract class GoogleDataColumn {

		protected DataColumn subjectColumn;
        private static string[] roles = new string[] { "annotation", "annotationText", "interval", "tooltip", "certainty", "emphasis", "scope" };
		/// 
		/// <param name="column"></param>
		internal GoogleDataColumn(DataColumn column){
            this.subjectColumn = column;
		}
        internal bool isRole(DataColumn cc)
        {
             if (cc.ExtendedProperties["role"] != null) return true;
            foreach (string r in roles)
            {
                if (cc.Caption == r)
                    return true;
            }

            return false;
        }

		internal string SerializedColumnIdentifier{
			get
            {


                if (isRole(subjectColumn))
                {
                    return string.Format("{{\"type\": \"{2}\", \"p\": {{ \"role\": \"{3}\" }} }}",
                   subjectColumn.ColumnName,
                   subjectColumn.ColumnName,
                   this.GoogleDataType,
                   string.IsNullOrEmpty(subjectColumn.Caption) ? subjectColumn.ExtendedProperties["role"] : subjectColumn.Caption);
                }
                else
                return string.Format("{{\"id\": \"{0}\", \"label\": \"{1}\", \"type\": \"{2}\"}}",
                    subjectColumn.ColumnName,
                    string.IsNullOrEmpty(subjectColumn.Caption) ? subjectColumn.ColumnName : subjectColumn.Caption, 
                    this.GoogleDataType);
			}
		}

		/// <summary>
		/// Returns in overridden methods the appropriately serialized string for the data
		/// type
		/// </summary>
		/// <param name="row"></param>
		protected internal virtual string SerializedValue(DataRow row){

			return "";
		}

		protected internal virtual string GoogleDataType{
			get{
				return "";
			}
		}

		/// 
		/// <param name="column"></param>
		public static GoogleDataColumn CreateGoogleDataColumn(DataColumn column){
            switch (column.DataType.FullName)
            {
                case "System.Boolean": return new BooleanGoogleDataColumn(column);
                case "System.Byte": return new NumberGoogleDataColumn(column);
                case "System.Char": return new StringGoogleDataColumn(column);
                case "System.DateTime":
                    if (column.ExtendedProperties.ContainsKey("GoogleDateType"))
                    {
                        switch ((GoogleDateType)column.ExtendedProperties["GoogleDateType"])
                        {
                            case GoogleDateType.Date: return new DateGoogleDataColumn(column);
                            case GoogleDateType.TimeOfDay: return new TimeOfDayGoogleDataColumn(column);
                            default: return new DateTimeGoogleDataColumn(column);
                        }
                    }
                    else
                        return new DateTimeGoogleDataColumn(column);

                case "System.Decimal": return new NumberGoogleDataColumn(column);
                case "System.Double": return new NumberGoogleDataColumn(column);
                case "System.Int16": return new NumberGoogleDataColumn(column);
                case "System.Int32": return new NumberGoogleDataColumn(column);
                case "System.Int64": return new NumberGoogleDataColumn(column);
                case "System.SByte": return new NumberGoogleDataColumn(column);
                case "System.Single": return new NumberGoogleDataColumn(column);
                case "System.String": return new StringGoogleDataColumn(column);
                case "System.TimeSpan": return new StringGoogleDataColumn(column);
                case "System.UInt16": return new NumberGoogleDataColumn(column);
                case "System.UInt32": return new NumberGoogleDataColumn(column);
                case "System.UInt64": return new NumberGoogleDataColumn(column);
                default: return new StringGoogleDataColumn(column);
            }
        }

	}//end GoogleDataColumn

}//end namespace Columns