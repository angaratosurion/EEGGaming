using NeuroSDK;
using NeuroTech.Spectrum;
using CsvHelper;
using System.Globalization;
using EEGGaming.Core.Tools;
using Neurotech.Filters;
using EEGGaming.Core.Data.NonDataModels;
using System.Drawing;
using EEGGaming.Core.Data.Models;
using NLog.LayoutRenderers.Wrappers;
using ScottPlot;
using System.Collections.Generic;
using System.Collections.Immutable;
//using NLog.Filters;

namespace EEGGaming.Core.Managers
{
    public delegate void OnBlinked();
    public  class BrainWaveRecordManager:BaseManager
    {
       int blinkcnt = 0;
       
       public static NeuroSDK.Scanner scanner = new NeuroSDK.Scanner(SensorFamily.SensorLEBrainBit);
        public List<BrainwavesRecord> Records { get; set; }
        const double VOLTENERG = 0.0001;
        BrainBitSensor? sensor = null;
        SpectrumMath math;
        FilterList flist;//= new FilterList();
        DateTime startedat;
        double newalphaval, newavbgo1o2 = 0,newvalalpharel,totalbinpower;
        public System.Timers.Timer tmrBlink { get; set; }
          
        
        public event OnBlinked OnBlinked;
        public int SamplesRecorded { get{ return Records.Count(); } }
        public Boolean EnableFiltering { get; set; }
        public int SamplingRate { get; set; }
        public int FFtWindow { get; set; }
        public int ProcessWinRate { get; set; }
        public double FFTBinsFor1Hz { get
            { return math.GetFFTBinsFor1Hz(); } }
        public BrainBitSensor ?Sensor 
        { get { return sensor; }
        }
        public Boolean Blinked { get; set; }
         
        public int ActiveUserId { get; set; }
        public int ActiveGamingSessionId { get; set; }
        public bool UsesDb { get; set; }
        //
        //scanner.EventSensorsChanged +=  onDeviceFound;
        public BrainWaveRecordManager():base()
        {

            try
            {
                Records= new List<BrainwavesRecord> ();
                scanner.EventSensorsChanged += onDeviceFound;
                scanner.Start();
                SamplingRate = 250;// raw signal sampling frequency
                FFtWindow = 500;  // spectrum calculation window length
                ProcessWinRate = 5;// *4;//5; // spectrum calculation frequency
                                   
                tmrBlink = new System.Timers.Timer(this.FFtWindow);
               
                tmrBlink.Elapsed += TmrBlink_Elapsed;
               
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);

            }



        }
        public void LoadCsv(string filename)
        {
            try
            {
                if (filename != null && File.Exists(filename))
                {
                    this.Records.Clear ();
                    using var reader = new StreamReader(filename);
                    using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
                    var recs = csv.GetRecords<BrainwavesRecord>().ToList();
                    Records.AddRange(recs);
                    reader.Close();
                    csv.Dispose();

                }
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);

            }
        }
        public void MakeGraphs(string filename)
        {
            try
            {
                if (filename != null && Records != null && Records.Count > 0)
                {
                    int imagewidth = 4000, imageheight = 4000;
                    int count = Records.Count;// * 2;
                    double[] alpha_avgch = new double[count];
                    double[] beta_avgch = new double[count];
                    double[] gamma_avgch = new double[count];
                    double[] delta_avgch = new double[count];
                    double[] theta_avgch = new double[count];

                    double[] alpha_ch1 = new double[count];
                    double[] beta_ch1 = new double[count];
                    double[] gamma_ch1 = new double[count];
                    double[] delta_ch1 = new double[count];
                    double[] theta_ch1 = new double[count];

                    double[] alpha_ch2 = new double[count];
                    double[] beta_ch2 = new double[count];
                    double[] gamma_ch2 = new double[count];
                    double[] delta_ch2 = new double[count];
                    double[] theta_ch2 = new double[count];
                    double[] seconds= new double[count];



                    if ((alpha_avgch != null && beta_avgch != null && gamma_avgch != null && delta_avgch != null 
                        && theta_avgch != null) && (alpha_ch1 != null && beta_ch1 != null && gamma_ch1 != null && delta_ch1 != null
                        && theta_ch1 != null) 
                        && (alpha_ch2 != null && beta_ch2 != null && gamma_ch2 != null && delta_ch2 != null
                        && theta_ch2 != null))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            alpha_avgch[i] = Records[i].Alpha1_avgch;
                            beta_avgch[i] = Records[i].Beta1_avgch;
                            gamma_avgch[i] = Records[i].Gamma1_avgch;
                            delta_avgch[i] = Records[i].Delta_avgch;
                            theta_avgch[i] = Records[i].Theta_avgch;

                            alpha_ch1[i] = Records[i].Alpha1_ch1;
                            beta_ch1[i] = Records[i].Beta1_ch1;
                            gamma_ch1[i] = Records[i].Gamma1_ch1;
                            delta_ch1[i] = Records[i].Delta_ch1;
                            theta_ch1[i] = Records[i].Theta_ch1;

                            alpha_ch2[i] = Records[i].Alpha1_ch2;
                            beta_ch2[i] = Records[i].Beta1_ch2;
                            gamma_ch2[i] = Records[i].Gamma1_ch2;
                            delta_ch2[i] = Records[i].Delta_ch2;
                            theta_ch2[i] = Records[i].Theta_ch2;
                            seconds[i] = Records[i].Second;

                        }


                       

                        ScottPlot.Plot plt = new ScottPlot.Plot();
                        plt.Add.ScatterLine(seconds, alpha_avgch, Colors.Blue);
                        plt.Add.ScatterLine(seconds, beta_avgch, Colors.Green);
                        plt.Add.ScatterLine(seconds, gamma_avgch, Colors.Red);
                        plt.Add.ScatterLine(seconds, delta_avgch, Colors.Orange);
                        plt.Add.ScatterLine(seconds, theta_avgch, Colors.Purple);

                        plt.Add.ScatterLine(seconds, alpha_ch1, Colors.AliceBlue);
                        plt.Add.ScatterLine(seconds, beta_ch1, Colors.GreenYellow);
                        plt.Add.ScatterLine(seconds, gamma_ch1, Colors.DarkRed);
                        plt.Add.ScatterLine(seconds, delta_ch1, Colors.OliveDrab);
                        plt.Add.ScatterLine(seconds, theta_ch1, Colors.RebeccaPurple);

                        plt.Add.ScatterLine(seconds, alpha_ch2, Colors.BlueViolet);
                        plt.Add.ScatterLine(seconds, beta_ch2, Colors.DarkGreen);
                        plt.Add.ScatterLine(seconds, gamma_ch2, Colors.IndianRed);
                        plt.Add.ScatterLine(seconds, delta_ch2, Colors.DarkOrange);
                        plt.Add.ScatterLine(seconds, theta_ch2, Colors.MediumPurple);

                        LegendItem item_alpha_avgch = new LegendItem();
                        item_alpha_avgch.LabelText = "Average  Raw Alpha Value of the 2 channels ";
                        item_alpha_avgch.FillColor = Colors.Blue;
                        LegendItem item_beta_avgch = new LegendItem();
                        item_beta_avgch.LabelText = "Average  Raw Beta Value of the 2 channels ";
                        item_beta_avgch.FillColor = Colors.Green;
                        LegendItem item_gamma_avgch = new LegendItem();
                        item_gamma_avgch.LabelText = "Average  Raw Gamma Value of the 2 channels ";
                        item_gamma_avgch.FillColor = Colors.Red;
                        LegendItem item_delta_avgch = new LegendItem();
                        item_delta_avgch.LabelText = "Average  Raw Delta Value of the 2 channels ";
                        item_delta_avgch.FillColor = Colors.Orange;
                        LegendItem item_theta_avgch = new LegendItem();
                        item_theta_avgch.LabelText = "Average  Raw Theta Value of the 2 channels ";
                        item_theta_avgch.FillColor = Colors.Purple;

                        LegendItem item_alpha_ch1 = new LegendItem();
                        item_alpha_ch1.LabelText = " Raw Alpha Value of Channel 1 ";
                        item_alpha_ch1.FillColor = Colors.AliceBlue;
                        LegendItem item_beta_ch1 = new LegendItem();
                        item_beta_ch1.LabelText = "Raw Beta Value of Channel 1 ";
                        item_beta_ch1.FillColor = Colors.GreenYellow;
                        LegendItem item_gamma_ch1 = new LegendItem();
                        item_gamma_ch1.LabelText = "Raw Gamma Value of Channel 1 ";
                        item_gamma_ch1.FillColor = Colors.DarkRed;
                        LegendItem item_delta_ch1 = new LegendItem();
                        item_delta_ch1.LabelText = "Raw Delta Value of Channel 1 ";
                        item_delta_ch1.FillColor = Colors.OliveDrab;
                        LegendItem item_theta_ch1 = new LegendItem();
                        item_theta_ch1.LabelText = "Raw Theta Value of Channel 1 ";
                        item_theta_ch1.FillColor = Colors.RebeccaPurple;

                        LegendItem item_alpha_ch2 = new LegendItem();
                        item_alpha_ch2.LabelText = " Raw Alpha Value of Channel 2 ";
                        item_alpha_ch2.FillColor = Colors.BlueViolet;
                        LegendItem item_beta_ch2 = new LegendItem();
                        item_beta_ch2.LabelText = "Raw Beta Value of Channel 2 ";
                        item_beta_ch2.FillColor = Colors.DarkGreen;
                        LegendItem item_gamma_ch2 = new LegendItem();
                        item_gamma_ch2.LabelText = "Raw Gamma Value of Channel 2 ";
                        item_gamma_ch2.FillColor = Colors.IndianRed;
                        LegendItem item_delta_ch2 = new LegendItem();
                        item_delta_ch2.LabelText = "Raw Delta Value of Channel 2 ";
                        item_delta_ch2.FillColor = Colors.DarkOrange;
                        LegendItem item_theta_ch2 = new LegendItem();
                        item_theta_ch2.LabelText = "Raw Theta Value of Channel 2 ";
                        item_theta_ch2.FillColor = Colors.MediumPurple;
                        LegendItem[] legitem = { item_alpha_avgch, item_beta_avgch, item_gamma_avgch, item_delta_avgch, item_theta_avgch,
                         item_alpha_ch1 , item_beta_ch1 , item_gamma_ch1 , item_delta_ch1 , item_theta_ch1 ,
                            item_alpha_ch2 , item_beta_ch2 , item_gamma_ch2 , item_delta_ch2 , item_theta_ch2 };
                        plt.ShowLegend(legitem);

                        plt.YLabel("Amplitude (V)");
                        plt.XLabel("Seconds");
                        // plt.XLabel("Frequency (Hz)");
                        plt.ShowLegend();
                        string tfilname = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename));
                        plt.SaveJpeg(tfilname + "-Amplitude (V).jpg", imagewidth, imageheight, 95);
                        plt.Dispose();

                        plt = new ScottPlot.Plot();
                        plt.Add.ScatterLine(seconds, alpha_avgch, Colors.Blue);

                        plt.Add.ScatterLine(seconds, alpha_ch1, Colors.AliceBlue);

                        plt.Add.ScatterLine(seconds, alpha_ch2, Colors.BlueViolet);

                        legitem = null;

                        // legitem = {item_alpha_avgch,item_alpha_ch1,item_alpha_ch2};
                        legitem = new LegendItem[3];
                        legitem[0] = item_alpha_avgch;
                        legitem[1] = item_alpha_ch1;
                        legitem[2] = item_alpha_ch2;

                        plt.ShowLegend(legitem);

                        plt.YLabel("Amplitude (V)");
                        plt.XLabel("Seconds");
                        plt.ShowLegend();
                        tfilname = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename));
                        plt.SaveJpeg(tfilname + "-Amplitude (V)-onlylphawave.jpg", imagewidth, imageheight, 95);
                        plt.Dispose();
                      

                        



                    }
                }
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);

            }
        }

        public void Connect(SensorInfo sens)
        {
            try
            {
                
                    sensor = scanner.CreateSensor(sens) as BrainBitSensor;
              

                  sensor.EventBrainBitSignalDataRecived += onBrainBitSignalDataRecived;
               


            }
            catch (Exception ex )
            {

                CommonTools.ErrorReporting(ex);
            }
        }

       
        public void Start ()
        {
            try
            {
               
                {
                    
                    while  (sensor == null && scanner.Sensors.Count==0 
                       )
                    {
                      
                       scanner.Start();
                        Thread.Sleep(15000 );
                        
                        this.Connect(scanner.Sensors[0]);
                       
                    }
                 
                    if (EnableFiltering)
                    {
                        this.InitFiltering();
                    }
                    math = new SpectrumMath(SamplingRate, FFtWindow, ProcessWinRate);
                    sensor.ExecCommand(SensorCommand.CommandStartSignal);
                    
                    Records.Clear();
                   
                    startedat = DateTime.Now;

                     tmrBlink.Start();
                   
                    
                    if (( this.ActiveUserId != 0 && this.ActiveGamingSessionId != 0) &&(this.UsesDb==true))
                    {
                       
                        this.AddNewRange(Records.ToArray());
                        
                    }
                    
                   



                }



            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);
            }
        }

        public void Stop()
        {
            try
            {
                if (sensor != null)
                {
                    
                   // var f =Records[0];
                    sensor.Disconnect();
                    sensor.ExecCommand(SensorCommand.CommandStopSignal);

                    sensor.Dispose();
                    sensor = null;
                    math.ClearData();
                    if (flist != null)
                    {
                        flist.Dispose();
                    }
                }
                
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
        public void StopAndSavetoDatabse()
        {
            try
            {
                if (sensor != null)
                {
 
                    sensor.Disconnect();
                    sensor.ExecCommand(SensorCommand.CommandStopSignal);

                    sensor.Dispose();
                    sensor = null;
                    math.ClearData();
                    if (flist != null)
                    {
                        flist.Dispose();
                    }
                    
                    SavetoDatabse();
                }

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
        public async void SavetoDatabse()
        {
            try
            {
               

                    
                    
                   // if (Records != null && this.ActiveGamingSessionId != 0 && this.ActiveUserId != 0)
                    {
                        foreach (var rec in  Records)
                        {
                            rec.GamingSessionId = this.ActiveGamingSessionId;
                            rec.UserId = ActiveUserId;

                        }
                        var recs = Records.ToArray();

                        await this.AddNewRange(recs);
                    }
                
            }
            catch (Exception ex)
            {
                throw;
                 
                 CommonTools.ErrorReporting(ex);
            }
        }
        public  void SaveToCSV(string filename)
        {
            try
            {
                if (filename != null)
                {
                    using var writer = new StreamWriter(filename);
                    using var csv = new CsvWriter(writer, CultureInfo.CurrentCulture);
                    
                    csv.WriteHeader<BrainwavesRecord>();
                    csv.NextRecord();
                    foreach (var rec in Records)
                    {
                        csv.WriteRecord(rec);
                        csv.NextRecord();
                    }
                    csv.Flush();
                    writer.Flush();
                  

                }
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
     void onDeviceFound(NeuroSDK.IScanner scanner, IReadOnlyList<SensorInfo> sensors)
        {
            try
            {
                if (sensors != null)
                {
                    this.Connect(sensors[0]);
                    scanner.Stop();
                }
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
        private void onBrainBitSignalDataRecived(ISensor sensor, BrainBitSignalData[] data)
        {
            try
            {


                //  Console.WriteLine("Data: " + data);
               // double[] vals = new double[data.Length * 4];
                double[] vals  = new double[data.Length];
                double[] vals1 = new double[data.Length];
                double[] vals2 = new double[data.Length];
                //double[]  fvals = new double[data.Length];
                BrainwavesRecord record = new BrainwavesRecord();
                TimeSpan secs = DateTime.Now.Subtract(startedat);
               
            
               // this.bitdata.Clear();
                for (int i = 0; i < data.Length; i++)
                {
                   
                    vals1[i] = data[i ].O1-data[1].T3;
                   
                    record.Marker = data[i].Marker;
                    record.PackNumber = data[i].PackNum;
                    
                    
                    
                    


                }
                for (int i = 0; i < data.Length; i++)
                {


                    vals2[i] = data[i].O2 - data[i].T4;




                }
                for (int i = 0; i < data.Length; i++)
                {

                    double[] vals3 = new double[2];
                    vals3[0] = vals1[i];
                    vals3[1] = vals2[i];

                    //vals[i] =Calculations.AverageAbs(vals3);
                    vals[i] = Calculations.Average(vals3);




                }

                this.FilterArrayInPlace(vals);
                this.FilterArrayInPlace(vals1);
                this.FilterArrayInPlace(vals2);


                math.ComputeSpectrum(vals);

                WavesSpectrumData freq = math.ReadWavesSpectrumInfo();
                math.ComputeSpectrum(vals1);
                WavesSpectrumData freq1  =math.ReadWavesSpectrumInfo();
                math.ComputeSpectrum(vals2);
                WavesSpectrumData freq2 = math.ReadWavesSpectrumInfo();




                if ((freq.Alpha_Raw != 0.0 && freq.BetaRaw != 0.0 && freq.GammaRaw != 0.0
                     && freq.DeltaRaw != 0 && freq.ThetaRaw != 0.0) && (freq1.Alpha_Raw != 0.0 && freq1.BetaRaw != 0.0 && freq1.GammaRaw != 0.0
                     && freq1.DeltaRaw != 0 && freq1.ThetaRaw != 0.0) &&(freq2.Alpha_Raw != 0.0 && freq2.BetaRaw != 0.0 && freq2.GammaRaw != 0.0
                     && freq2.DeltaRaw != 0 && freq2.ThetaRaw != 0.0))
                {
                    newalphaval = freq.Alpha_Raw;//*100000;
                    newvalalpharel = freq.Alpha_Rel;

                    record.Alpha1_avgch = freq.Alpha_Raw;
                    record.Beta1_avgch = freq.BetaRaw;
                    record.Gamma1_avgch = freq.GammaRaw;
                    record.Delta_avgch = freq.DeltaRaw;
                    record.Theta_avgch = freq.ThetaRaw;
                    
                    record.Alpha1_Rel_avgch = freq.Alpha_Rel;
                    record.Beta1_Rel_avgch = freq.BetaRel;
                    record.Gamma1_Rel_avgch = freq.GammaRel;
                    record.Delta_Rel_avgch = freq.DeltaRel;
                    record.Theta_Rel_avgch = freq.ThetaRel;

                    record.Alpha1_ch1 = freq1.Alpha_Raw;
                    record.Beta1_ch1 = freq1.BetaRaw;
                    record.Gamma1_ch1 = freq1.GammaRaw;
                    record.Delta_ch1 = freq1.DeltaRaw;
                    record.Theta_ch1 = freq1.ThetaRaw;

                    record.Alpha1_Rel_ch1 = freq2.Alpha_Rel;
                    record.Beta1_Rel_ch1 = freq2.BetaRel;
                    record.Gamma1_Rel_ch1 = freq2.GammaRel;
                    record.Delta_Rel_ch1 = freq2.DeltaRel;
                    record.Theta_Rel_ch1 = freq2.ThetaRel;

                    record.Alpha1_ch2 = freq2.Alpha_Raw;
                    record.Beta1_ch2 = freq2.BetaRaw;
                    record.Gamma1_ch2 = freq2.GammaRaw;
                    record.Delta_ch2 = freq2.DeltaRaw;
                    record.Theta_ch2 = freq2.ThetaRaw;

                    record.Alpha1_Rel_ch2 = freq2.Alpha_Rel;
                    record.Beta1_Rel_ch2 = freq2.BetaRel;
                    record.Gamma1_Rel_ch2 = freq2.GammaRel;
                    record.Delta_Rel_ch2 = freq2.DeltaRel;
                    record.Theta_Rel_ch2 = freq2.ThetaRel;

                    record.GamingSessionId = this.ActiveGamingSessionId;
                    record.UserId = this.ActiveUserId;
                    record.Date = DateTime.Now.ToShortDateString();
                    record.Time = DateTime.Now.ToLongTimeString();
                    record.Second = secs.TotalSeconds;
                    record.MiliSecond = secs.TotalMilliseconds;
                    record.Blinked = Blinked;




                    Blinked = false;
                    Records.Add(record);
                   // this.DetectBlink();


                    //  this.bitdata.Add(voltagesNodes);
                }





            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }

        }
       

        private void TmrBlink_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
               
                this.DetectBlink();
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }

        public void FilterArrayInPlace( double[] vals)
        {
            try
            {
                if( vals !=null && EnableFiltering)
                { 
                        if (flist == null)
                        {
                            this.InitFiltering();
                        }
                        flist.FilterArray(vals);
                   
                }
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
       
        public void InitFiltering()
        {
            try
            {
                 flist = new FilterList();
                IIRFilterParam[] preinstallFilters = PreinstalledFilters.List();
              
             
                IIRFilterParam filterparam50hzbs = preinstallFilters.FirstOrDefault(x => x.cutoffFreq == 50 && x.type == IIRFilterType.FtBandStop 
                && x.samplingFreq == SamplingRate);
                IIRFilterParam filterparam60hzbs = preinstallFilters.FirstOrDefault(x => x.cutoffFreq == 60 && x.type == IIRFilterType.FtBandStop 
                && x.samplingFreq == SamplingRate);


                IIRFilter reymastin50hzBS = new IIRFilter(filterparam50hzbs);
                IIRFilter reymastin60hzBS = new IIRFilter(filterparam60hzbs);







                flist.AddFilter(reymastin50hzBS);
                flist.AddFilter(reymastin60hzBS);

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
        public Boolean DetectBlink()
        {
            try
            {
                Boolean ap = false;
                double[] oldval = new double[Records.Count];
                double[] chn1val = new double[Records.Count];
              
                if (Records.Count > 0)
                {
                    for (int i = 0; i < this.Records.Count; i++)
                    {
                        oldval[i] = this.Records[i].Alpha1_avgch;
                    }
                    for (int i = 0; i < this.Records.Count; i++)
                    {
                        chn1val[i] = this.Records[i].Alpha1_ch1;
                    }
                   
                    if (this.DetectBlinkusingAlpha(oldval, chn1val))
                    {
                         blinkcnt++;
                        

                    }
                   if (blinkcnt > 2)//(blinkcnt > 3)
                        {

                        Blinked = true;
                        Records[Records.Count-1].Blinked = true;
                        OnBlinked?.Invoke();
                        ap = true;
                        blinkcnt = 0;

                    }





                }
                return ap;
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return false;
            }
        }
        public Boolean DetectBlinkusingAlpha(double[] oldvals, double [] chanel1vals)//,double [] chanenl2vals)
        {
            try
            {
                Boolean ap = false;
            
                for (int i = 0; i < oldvals.Length; i++)
                {
                    if (((Calculations.Subtruck(Calculations.AverageAbs(oldvals), oldvals[i]) > VOLTENERG) 
                        && (oldvals[i] > VOLTENERG))&&
                        ((Calculations.Subtruck(Calculations.AverageAbs(chanel1vals), chanel1vals[i]) > VOLTENERG)
                        && (chanel1vals[i] > VOLTENERG))) 
                    {
                        ap = true;
                    }
                }



                return ap;
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return false;
            }
        }
        public void AddNew(BrainwavesRecord record)
        {
            try
            {
                if (record != null)
                {
                    record.Id = PredictLastId("BrainwavesRecord") + 1;
                    DbContext.BrainWaves.Add(record);
                    DbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }

        }
        public async         Task
AddNewRange(BrainwavesRecord[] record)
        {
            try
            {
                if (record != null)
                {
                     

                    foreach (var record2 in record)
                    {
                        record2.Id = PredictLastId("BrainwavesRecord") + 1;
                        

                    }
                   await  DbContext.BrainWaves.AddRangeAsync(record);
                   await  DbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }

        }
        public void Edit (int id ,BrainwavesRecord record)
        {
            try
            {
                if (record != null && id > 0)
                {
                    var oldrec = this.GetBrainwaveFromDBById(id);
                    if (oldrec != null)
                    {
                        record.Id = oldrec.Id;
                        DbContext.Entry(oldrec).CurrentValues.SetValues(record);
                        DbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }
        }
        public void EditRange(   BrainwavesRecord []  records)
        {
            try
            {

                if (records != null  )
                {
                    foreach (var record in records)
                    {
                        var oldrec = this.GetBrainwaveFromDBById(record.Id);
                        if (oldrec != null)
                        {
                            record.Id = oldrec.Id;
                            DbContext.Entry(oldrec).CurrentValues.SetValues(record);
                           
                        }
                    }
                    DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }
        }
        public List<BrainwavesRecord> GetBrainwavesFromDB()
        {
            try
            {
                return this.DbContext.BrainWaves.ToList();

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return null;
            }

        }
        public List<BrainwavesRecord> GetBrainwavesFromDBByUserId(int id)
        {
            try
            {
                List<BrainwavesRecord> ap;

                 
                    var tap = this.GetBrainwavesFromDB();
                     
                    ap = tap.FindAll(x => x.UserId == id);



                return ap;

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);

                return null;
               
            }

        }
        public BrainwavesRecord GetBrainwaveFromDBById(int id)
        {
            try
            {
                BrainwavesRecord ap;


                var tap = this.GetBrainwavesFromDB();

                ap = tap.Find(x => x.Id == id);



                return ap;

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);

                return null;

            }

        }
        public List<BrainwavesRecord> GetBrainwavesFromDBByGamingSessionId(int id)
        {
            try
            {
                List<BrainwavesRecord> ap;


                var tap = this.GetBrainwavesFromDB();

                ap = tap.FindAll(x => x.GamingSessionId == id);

                return ap;



            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return null;
                 
            }

        }
        public List<BrainwavesRecord> GetBrainwavesFromDBByMilisconds(double milsecond)
        {
            try
            {
                List<BrainwavesRecord> ap;


                var tap = this.GetBrainwavesFromDB();

                ap = tap.FindAll(x => x.MiliSecond== milsecond);



                return ap;

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return null;

            }

        }

    }
}
