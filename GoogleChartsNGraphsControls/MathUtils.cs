using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleChartsNGraphsControls
{
    public class MathUtils
    {
        #region Math Calcs
        //
        // MAth Calcs from 
        // http://www.codeproject.com/Articles/42492/Using-LINQ-to-Calculate-Basic-Statistics
        //

        public static decimal Median(IEnumerable<decimal> source)
        {
            var sortedList = from number in source
                             orderby number
                             select number;

            int count = sortedList.Count();
            int itemIndex = count / 2;
            if (count % 2 == 0) // Even number of items. 
                return (sortedList.ElementAt(itemIndex) +
                        sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items. 
            return sortedList.ElementAt(itemIndex);
        }
        public static decimal StandardDeviation(IEnumerable<decimal> source)
        {
            return decimal.Parse(Math.Sqrt((double)source.Variance()).ToString());
        }
        public static decimal Variance(IEnumerable<decimal> source)
        {
            int n = 0;
            decimal mean = 0;
            decimal M2 = 0;

            foreach (decimal x in source)
            {
                n = n + 1;
                decimal delta = x - mean;
                mean = mean + delta / n;
                M2 += delta * (x - mean);
            }
            return M2 / (n - 1);
        }
        #endregion
    }
}
