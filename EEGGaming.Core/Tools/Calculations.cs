using System.Runtime.CompilerServices;

namespace EEGGaming.Core.Tools
{/// <summary>
/// Class that does Mathematic Calculations 
/// </summary>
    public static class Calculations
    {
        /// <summary>
        /// Calculates the absolute values of the given's array average
        /// </summary>
        /// <param name="vals">array to calculate it's average value </param>
        /// <returns>the absolute values of the given's array average</returns>
        public static double AverageAbs(double[] vals)
        {
            try
            {
                double ap = 0;
                if (vals != null)
                {
                   ap= Math.Abs(Average(vals));
                }
                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return 0;
            }

        }
        /// <summary>
        /// Calculates the average of the given array
        /// </summary>
        /// <param name="vals">the array we want to get its average value </param>
        /// <returns>average of the given array</returns>
        public static double Average(double[] vals)
        {
            try
            {
                double ap = 0;
                if (vals != null)
                {
                    ap = vals.Sum()/vals.Length;
                }
                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return 0;
            }

        }
        /// <summary>
        /// Subtracts val2 from val1
        /// </summary>
        /// <param name="val1">the valueto subtruck from </param>
        /// <param name="val2"> the value to   subtruct</param>
        /// <returns>the difference of val1-val2</returns>
        public static double Subtruck(double val1,double val2)
        {
            try
            {
                double ap = 0;

                ap = val1 - val2;
                
                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return 0;
            }

        }
 
      
    }
}

