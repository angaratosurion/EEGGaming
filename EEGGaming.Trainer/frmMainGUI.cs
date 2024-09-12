using EEGGaming.Core.Managers;
using EEGGaming.Core.Tools;
using NeuroSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EEGGaming.Trainer
{
    public partial class frmMainGUI : Form
    {
        BrainWaveRecordManager recordManager = new BrainWaveRecordManager();
        String winTitle = Application.ProductName + " - " + Application.ProductVersion + " Core Library version : " + CommonTools.GetEEGGamingCoreVersion();
        DateTime started;
        public frmMainGUI()
        {
            InitializeComponent();
            this.Text = winTitle;// +" "+Convert.ToString( recordManager.FFTBinsFor1Hz);
            recordManager.OnBlinked += RecordManager_OnBlinked;
            recordManager.ActiveGamingSessionId = 1;
            recordManager.ActiveUserId = 1;
            // recordManager.AutoSave= true;
            recordManager.UsesDb = false;
        }

        private void RecordManager_OnBlinked()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
            var waves=this.recordManager.GetBrainwavesFromDBByMilisconds(0);
            if (waves != null)
            {
                foreach (var wave in waves)
                {
                    wave.Blinked = true;
                    
                }
                this.recordManager.EditRange(waves.ToArray());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {



                recordManager.EnableFiltering = cbxEnableFiltering.Checked;

                recordManager.Start();


                this.started = DateTime.Now;
                this.Text = winTitle + String.Format(" Device Name [ Started]: {0} ", recordManager.Sensor.Name) + " " + Convert.ToString(recordManager.FFTBinsFor1Hz); ;
                this.timer1.Enabled = true;

                this.timer1.Start();




            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.Text = winTitle + String.Format(" Device Name [ Stoped]: {0} ", recordManager.Sensor.Name);
                recordManager.Stop();

                this.timer1.Stop();
                this.timer1.Enabled = false;
            }
            catch (Exception ex)
            {


                CommonTools.ErrorReporting(ex);

            }
        }

        private void btnBlinked_Click(object sender, EventArgs e)
        {
            try
            {
                recordManager.Blinked = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmMainGUI_Load(object sender, EventArgs e)
        {
            string path = CommonTools.GetAppRootDataFolderAbsolutePath();
            string filename = DateTime.Now.ToString().Replace("/", "-");
            filename.Replace(":", ".");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = CommonTools.GetAppRootDataFolderAbsolutePath();
                string filename = DateTime.Now.ToString().Replace("/", "-") + ".csv";
                filename = filename.Replace(":", ".");

                recordManager.SaveToCSV(Path.Combine(path, filename));

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan res = DateTime.Now.Subtract(started);
            this.lblElapsed.Text = res.Hours.ToString() + ":" + res.Minutes + ":" + res.Seconds.ToString();
            this.lblSampleCount.Text = Convert.ToString(recordManager.SamplesRecorded);
            if (recordManager.Sensor != null)
            {
                this.lblBatteryLvl.Text = recordManager.Sensor.BattPower + "%";
            }
        }

        private void btnfft_Click(object sender, EventArgs e)
        {
            //var res = this.saveFileDialog1.ShowDialog();
            //if (res == DialogResult.OK && saveFileDialog1.FileName != null)
            //{
            //    recordManager.TransformToFFT(saveFileDialog1.FileName);

            //}
        }

        private void btnLoadCsv_Click(object sender, EventArgs e)
        {
            var res = this.openFileDialog1.ShowDialog();
            if (res == DialogResult.OK && openFileDialog1.FileName != null)
            {
                recordManager.LoadCsv(openFileDialog1.FileName);

            }
        }

        private void btnMakeGraphs_Click(object sender, EventArgs e)
        {

            var res= this.saveFileDialog1.ShowDialog();
            if (  res == DialogResult.OK && saveFileDialog1.FileName != null)
            {
                recordManager.MakeGraphs(saveFileDialog1.FileName);

            }
        }
    }
}
