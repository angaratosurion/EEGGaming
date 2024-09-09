using System.Runtime.CompilerServices;

namespace EEGGaming.Core.Tools
{
    public static class Calculations
    {
        //List<BrainwavesRecord> records = new List<BrainwavesRecord>();

        /*  var window = new FftSharp.Windows.Hanning();
                window.ApplyInPlace(vals);

                math.ComputeSpectrum(vals);
                // Calculate the FFT as an array of complex numbers
                System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(vals);

        //        // or get the magnitude (units²) or power (dB) as real numbers
        //        double[] magnitude = FftSharp.FFT.Magnitude(spectrum);*/
        //public  static  double[] FFTMagnitude(double[] vals)
        //{
        //    try
        //    {
        //        double[] ap = null ;
        //        if (vals != null)
        //        {
        //            var window = new FftSharp.Windows.Hanning();
        //            window.ApplyInPlace(vals);


        //            // Calculate the FFT as an array of complex numbers
        //            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(vals);

        //            // or get the magnitude (units²) or power (dB) as real numbers
        //            double[] magnitude = FftSharp.FFT.Magnitude(spectrum);

        //            // Calculate the FFT as an array of complex numbers

        //            ap = magnitude;
        //        }
        //        return ap;
        //    }
        //    catch (Exception ex)
        //    {

        //        CommonTools.ErrorReporting(ex);
        //        return null;
        //    }
        //}
        //public static double[] FFTPower(double[] vals)
        //{
        //    try
        //    {
        //        double[] ap = null;
        //        if (vals != null)
        //        {
        //            var window = new FftSharp.Windows.Hanning();
        //            window.ApplyInPlace(vals);


        //            // Calculate the FFT as an array of complex numbers
        //            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(vals);

        //            // or get the magnitude (units²) or power (dB) as real numbers
        //            double[] magnitude = FftSharp.FFT.Power(spectrum);

        //            // Calculate the FFT as an array of complex numbers

        //            ap = magnitude;
        //        }
        //        return ap;
        //    }
        //    catch (Exception ex)
        //    {

        //        CommonTools.ErrorReporting(ex);
        //        return null;
        //    }
        //}
        //public static double[] FFTAmplitude(double[] vals)
        //{
        //    try
        //    {
        //        double[] ap = null;
        //        if (vals != null)
        //        {
        //            var window = new FftSharp.Windows.Hanning();
        //            window.ApplyInPlace(vals);


        //            // Calculate the FFT as an array of complex numbers
        //            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(vals);

        //            // or get the magnitude (units²) or power (dB) as real numbers
        //            //  double[] magnitude = FftSharp.FFT.Power(spectrum);

        //            // Calculate the FFT as an array of complex numbers

        //            ap = vals;
        //        }
        //        return ap;
        //    }
        //    catch (Exception ex)
        //    {

        //        CommonTools.ErrorReporting(ex);
        //        return null;
        //    }
        //}
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
        public static double ConvertfromWtoUV(double power, double res)
        {

            try
            {
                double ap = 0;

                ap = Math.Sqrt(power * res*1000);

                return power;


            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return 0;
            }
        }
      
    }
}

