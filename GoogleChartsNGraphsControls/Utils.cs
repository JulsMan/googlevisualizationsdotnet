using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleChartsNGraphsControls
{
    public class Utils
    {
        private static bool IsNumber(object o)
        {
            if (o == null) return false;

            float foo;
            return float.TryParse(o.ToString(), out foo);
        }
        
        public enum AggregateFunction { Average, Count, Exists, First, Last, Max, Min, Sum };
        public enum SUMMARYOPTIONS { COLUMN, ROW, BOTH}
        private static object GetData(DataTable _SourceTable, string Filter, string DataField, AggregateFunction Aggregate)
        {
            try
            {
                DataRow[] FilteredRows = _SourceTable.Select(Filter);
                List<object> objList =
                 FilteredRows.Select(x => x.Field<object>(DataField)).ToList();

                switch (Aggregate)
                {
                    case AggregateFunction.Average:
                        {
                            for (int i = 0; i < objList.Count(); i++)
                                if (IsNumber(objList[i]) == false)
                                    objList.Remove(objList[i]);

                            return objList.Average(x => float.Parse(x.ToString()));
                        }
                    case AggregateFunction.Count:
                        return objList.Count();
                    case AggregateFunction.Exists:
                        return (objList.Count() == 0) ? "False" : "True";
                    case AggregateFunction.First:
                        return objList.FirstOrDefault();
                    case AggregateFunction.Last:
                        return objList.LastOrDefault();
                    case AggregateFunction.Max:
                        return objList.Max();
                    case AggregateFunction.Min:
                        return objList.Min();
                    case AggregateFunction.Sum:
                        {
                            for (int i = 0; i < objList.Count(); i++)
                                if (IsNumber(objList[i]) == false)
                                    objList[i] = 0;

                            return objList.Sum(x => float.Parse(x.ToString()));
                        }
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return "#Error";
            }
        }
        public static DataTable PivotData(DataTable _SourceTable, string RowField, string DataField, AggregateFunction Aggregate, params string[] ColumnFields)
        {
            DataTable dt = new DataTable();
            string Separator = ".";
            var RowList = (from x in _SourceTable.AsEnumerable()
                           select new { Name = x.Field<object>(RowField) })
                           .Distinct().OrderBy(x => x.Name);

            var ColList = (from x in _SourceTable.AsEnumerable()
                           select new
                           {
                               Name = ColumnFields.Select(n => x.Field<object>(n))
                               .Aggregate((a, b) => a += Separator + b.ToString())
                           })
                               .Distinct()
                               .OrderBy(m => m.Name);

            dt.Columns.Add(RowField);
            foreach (var col in ColList)
            {

                dt.Columns.Add(string.IsNullOrEmpty(col.Name.ToString()) ? "[Empty]" : col.Name.ToString(), typeof(float));
            }

            foreach (var RowName in RowList)
            {
                DataRow row = dt.NewRow();
                row[RowField] = RowName.Name.ToString();
                foreach (var col in ColList)
                {
                    string strFilter = RowField + " = '" + RowName.Name + "'";
                    string[] strColValues =
                      col.Name.ToString().Split(Separator.ToCharArray(),
                                                StringSplitOptions.None);
                    for (int i = 0; i < ColumnFields.Length; i++)
                        strFilter += " and " + ColumnFields[i] +
                                     " = '" + strColValues[i] + "'";

                    row[string.IsNullOrEmpty(col.Name.ToString()) ? "[Empty]" : col.Name.ToString()]
                        = GetData(_SourceTable, strFilter, DataField, Aggregate);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_SourceTable">The Datatable that will be added to</param>
        /// <param name="SummaryName">Name of the summary row or column</param>
        /// <returns></returns>
        public static DataTable AddSummary(DataTable _SourceTable, string SummaryName, SUMMARYOPTIONS SUMOPT)
        {
            if (SUMOPT == SUMMARYOPTIONS.COLUMN)
                return summaryColumn(_SourceTable, SummaryName);
            else if (SUMOPT == SUMMARYOPTIONS.ROW)
                return summaryRow(_SourceTable, SummaryName);
            else if (SUMOPT == SUMMARYOPTIONS.BOTH)
            {
                return _SourceTable = summaryColumn(summaryRow(_SourceTable, SummaryName), SummaryName);
            }
            else
                return _SourceTable;
        }
        private static DataTable summaryColumn(DataTable dt, string Name)
        {
            int iiColNumber = 0;
            List<object> newRow = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.DataType == typeof(string) || dc.DataType == typeof(bool) || dc.DataType == typeof(DateTime))
                {
                    if (iiColNumber == 0)
                        newRow.Add(Name);
                    else
                        newRow.Add("");
                }
                else
                {
                    if (dc.ColumnName.Contains(' '))
                    {
                        dc.ColumnName = dc.ColumnName.Replace(' ', '_');
                        dt.AcceptChanges();

                        object oo = dt.Compute(string.Format("Sum({0})", dc.ColumnName), "");
                        newRow.Add(oo);

                        dc.ColumnName = dc.ColumnName.Replace('_', ' ');
                        dt.AcceptChanges();
                    }
                    else
                    {
                        object oo = dt.Compute(string.Format("Sum({0})", dc.ColumnName), "");
                        newRow.Add(oo);
                    }
                }

                iiColNumber++;
            }

            dt.Rows.Add(newRow.ToArray());
            dt.AcceptChanges();
            return dt;
        }
        private static DataTable summaryRow(DataTable dt, string Name)
        {
            dt.Columns.Add(Name, typeof(float));
            foreach (DataRow row in dt.Rows)
            {
                float rowSum = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    if (!row.IsNull(col))
                    {
                        string stringValue = row[col].ToString();
                        float d;
                        if (float.TryParse(stringValue, out d))
                            rowSum += d;
                    }
                }
                row.SetField(Name, rowSum);
            }

            return dt;
        }

    }
}
